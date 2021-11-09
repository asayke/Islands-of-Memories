using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditorInternal;
using UnityEngine;
using static MaxQuantity;

// ReSharper disable PossibleInvalidOperationException
//TODO Сделать ивент добавления в инвентарь.

public class Inventory : MonoBehaviour, IInventory
{

    public int Capacity { get; private set; }

    //Проверяет полон ли инвентарь.
    public bool IsFull => _slots.All(x => x.IsFull);

    //Лист слотов.
    private List<IInventorySlot> _slots;

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
        var suitableSlot = _slots.Find(x => x.Item == item && !x.IsFull) ?? _slots.Find(x => x.IsEmpty);
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
            slot.Set(item);
        }
        else
            slot.Item.State.Amount += amountToAdd;

        var amountLeft = item.State.Amount - amountToAdd;
        if (amountLeft != 0)
        {
            item.State.Amount = amountLeft;
            TryToAdd(item);
        }
    }

    //TODO Сделать Remove метод.
    public void Remove(ItemType itemType, int amount = 1)
    {
        
    }

    //Выполняет тразит предметема с одного слота (from) в другой (to)
    public void Transit(IInventorySlot from, IInventorySlot to)
    {
        //Если слот в который мы переносим полный, выходим
        if (to.IsFull)
            return;
        //Если слот в который мы переносим неполный, но предмет по типу не подходит, выходим
        if (!to.IsEmpty && from.Item != to.Item)
            return;

        if (to.IsEmpty)
        {
            to.Set(from.Item);
            from.Clear();
        }
        
        //Проверяет, влезает ли в слот количество предметов, которые мы хотим положить.
        var isFits = from.Amount + to.Amount <= from.Item.Info.MaxQuantity;

        var amountToAdd = isFits ? from.Amount : from.Item.Info.MaxQuantity - to.Amount;
        var amountLeft = from.Amount - amountToAdd;

        to.Item.State.Amount += (int) amountToAdd;
        if (isFits)
            from.Clear();
        else
            from.Item.State.Amount = (int) amountLeft;
    }


    public IItem GetItem(string name)
    {
        return _slots.Find(x => x.Item.Info.Name == name).Item;
    }

    public IEnumerable<IItem> GetItems()
    {
        foreach (var slot in _slots)
            yield return slot.Item;
    }
}