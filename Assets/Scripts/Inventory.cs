using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private CellTemplate _cellTemplate;
    [SerializeField] private Transform _transform;
    public List<ItemInfo> _items = new List<ItemInfo>();
    private List<ItemInfo> _oldItems;
    //Максимальное кол-во слотов.
    private readonly int _maxSlots = 9;
    
    /// <summary>
    /// Максимальное количество предметов разных типов в инветоре,
    /// </summary>
    private readonly Dictionary<ItemType, int> _maxQuantity = new Dictionary<ItemType, int>()
    {
        [ItemType.Equipment] = 1,
        [ItemType.Tools] = 1,
        [ItemType.Weapons] = 1,
        [ItemType.Food] = 64,
        [ItemType.Foraging] = 64,
        [ItemType.Mining] = 20,
    };

    [Serializable]
    public class ItemInfo : IComparable<ItemInfo>
    {
        public Item Item;
        public int Count;
        private IComparable _comparableImplementation;

        public ItemInfo(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public int CompareTo(ItemInfo other)
        {
            return Count.CompareTo(other.Count);
        }
    }
    private void OnEnable()
    {
        Render();
    }
    
    private void Render()
    {
        foreach (Transform child in _transform)
            Destroy(child.gameObject);
        (_items, _oldItems) = (new List<ItemInfo>(), _items);
        foreach (var item in _oldItems)
        {
            //-1 флаг того, что нужно удалить, решение дерьмо - автор Александр))
            if (item.Count != -1)
                AddItem(item.Item,item.Count);
        }
        _oldItems = null;
    }
    
    public void AddItem(Item item, int amount)
    {
        //Находит первый предмент, схожий по item c поданным, и проверяет можно ли туда положить amount
        var itm = _items.Find(x => x.Item == item && x.Count + amount <= _maxQuantity[x.Item.ItemType]);
        if (itm != null)
        {
            _items[_items.FindIndex(x => x == itm)] = new ItemInfo(item, amount + itm.Count);
            Render();
        }
        else if (_items.Count() < _maxSlots)
        {
            _items.Add(new ItemInfo(item, amount));
            var cell = Instantiate(_cellTemplate, _transform);
            cell.Render(item, amount);
        }
        else print("Инвентарь полон!");
    }

    public void DeleteItem(Item item, int amount)
    {
        var deletes = _items.FindAll(x => x.Item == item);
        deletes.Sort();
        for (int i = 0; i < deletes.Count; i++)
        {
            if (deletes[i].Count - amount >= 0)
            {
                

                amount = 0;
            }
            if (amount == 0)
                break;
        } 
        Render();
    }
    
}
