using System;
using System.Collections.Generic;
using System.Linq;
using Debug = UnityEngine.Debug;

public class Inventory : IInventory
{
    public int Capacity { get; private set; }

    //Проверяет полон ли инвентарь.
    public bool IsFull => _slots.All(x => x.IsFull);
    public bool IsAllOccupied => _slots.All(x => !x.IsEmpty);
    
    //Лист слотов.
    private List<IInventorySlot> _slots;
    public event Action InventoryStateChanged;

    //Констуктор класса, подается ёмкость инвентаря.
    public Inventory(int capacity)
    {
        this.Capacity = capacity;
        _slots = new List<IInventorySlot>(capacity);
        for (var i = 0; i < capacity; i++)
            _slots.Add(new InventorySlot());
    }

    public void TryToAdd(IItem item)
    {
        //Если инвентарь полон. Нельзя ничего добавить, следовательно выходим.
        if (IsFull)
        {
            Debug.Log($"Cannot add item ({item.Info.ItemType}); amount ({item.State.Amount})");
            return;
        }

        //Сначала находим неполный слот, в котором лежит Item такого же типа, как подаваемый, если такого нет, то находим пустой слот.
        var suitableSlot = _slots.Find(x => x.Item?.Info.Type == item.Info.Type && !x.IsFull) ??
                           _slots.Find(x => x.IsEmpty);
        if (suitableSlot != null)
            AddItem(suitableSlot, item);
    }

    private void AddItem(IInventorySlot slot, IItem item)
    {
        //Проверяет, влезает ли в ячейку количество предметов, которые мы хотим положить.
        var isFits = slot.Amount + item.State.Amount <= item.Info.MaxQuantity;

        var amountToAdd = isFits ? item.State.Amount : item.Info.MaxQuantity - slot.Amount;
        if (slot.IsEmpty)
        {
            var clonedItem = item.Clone(amountToAdd);
            clonedItem.State.Amount = amountToAdd;
            slot.Set(clonedItem);
        }
        else
        {
            slot.Item.State.Amount += amountToAdd;
            OnInventoryStateChanged();
        }
        OnInventoryStateChanged();
        var amountLeft = item.State.Amount - amountToAdd;

        if (amountLeft > 0)
        {
            item.State.Amount = amountLeft;
            TryToAdd(item);
        }
    }

    public void RemoveFromSlot(Type type,IInventorySlot inventorySlot, int amount = 1)
    {
        if (amount > inventorySlot.Amount)
            throw new ArgumentException();
        inventorySlot.Item.State.Amount -= amount;
        if (inventorySlot.Amount <= 0)
            inventorySlot.Clear();
        OnInventoryStateChanged();
    }
    
    public void Remove(Type type, int amount = 1)
    {
        try
        {
            var itemsSlots = _slots.FindAll(x => !x.IsEmpty && x.Item.Info.Type == type);
            if (itemsSlots.Count != 0)
            {
                var count = itemsSlots.Count;
                for (var i = count - 1; i >= 0; ++i)
                {
                    var slot = itemsSlots[i];
                    if (slot.Amount >= amount)
                    {
                        slot.Item.State.Amount -= amount;
                        if (slot.Amount <= 0)
                            slot.Clear();
                        OnInventoryStateChanged();
                        return;
                    }
                    var amountLeft = amount - slot.Amount;
                    slot.Clear();
                    OnInventoryStateChanged();
                    Remove(type,amountLeft);
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

   
    

    //Выполняет тразит предметема с одного слота (from) в другой (to)
    public void Transit(IInventorySlot from, IInventorySlot to)
    {
        //Для того, чтобы при резком бросании элемента инвентаря предмет пропадал.
        if (from == to)
            return;
        //Если слот в который мы переносим полный, выходим
        if (to.IsFull)
            return;
        // //Если слот в который мы переносим неполный, но предмет по типу не подходит, выходим
        if (!to.IsEmpty && from.Item != to.Item)
            return;

        //Проверяет, влезает ли в слот количество предметов, которые мы хотим положить.
        var isFits = from.Amount + to.Amount <= from.Item.Info.MaxQuantity;
        var amountToAdd = isFits ? from.Amount : from.Item.Info.MaxQuantity - to.Amount;
        var amountLeft = from.Amount - amountToAdd;

        if (to.IsEmpty)
        {
            to.Set(from.Item);
            from.Clear();
            to.Item.State.Amount += amountToAdd;
            OnInventoryStateChanged();
            return;
        }
        to.Item.State.Amount += amountToAdd;
        if (isFits)
            from.Clear();
        else
            from.Item.State.Amount = amountLeft;
        OnInventoryStateChanged();
    }

    public IItem GetItem(string name)
    {
        return _slots.Find(x => x.Item.Info.Name == name).Item;
    }

    public IEnumerable<IInventorySlot> GetSlots()
    {
        return _slots;
    }

    public IEnumerable<IItem> GetItems()
    {
        foreach (var slot in _slots)
            yield return slot.Item;
    }

    public bool HasItem(IItemInfo itemInfo, int amount)
    {
        var b = GetItems()?.ToList().Where(x => x?.Info.Type == itemInfo.Type)
            .Aggregate(0, (x, y) => x + y.State.Amount);
        return b >= amount;
    }

    public bool HasItemByType(Type type)
    {
        var items = GetItems()?.ToList();
        if (items.Count == 0)
            return false;
        return items.Count(x => x != null && x.Info.Type == type) != 0;
    }
    
    
    private void OnInventoryStateChanged()
    {
        InventoryStateChanged?.Invoke();
    }
}