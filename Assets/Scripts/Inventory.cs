using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using System.Linq;
using System.Xml.Schema;
using NUnit.Framework;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCell;
    [SerializeField] private Transform _transform;
    [SerializeField] private List<ItemInfo> _items;
    private List<ItemInfo> _oldItems;
    //Максимальное кол-во слотов.
    private int _maxSlots = 9;
    /// <summary>
    /// Максимальное количество предметов разных типов в инветоре,
    /// </summary>
    private Dictionary<ItemType, int> _maxQuantity = new Dictionary<ItemType, int>()
    {
        [ItemType.Equipment] = 1,
        [ItemType.Tools] = 1,
        [ItemType.Weapons] = 1,
        [ItemType.Food] = 64,
        [ItemType.Foraging] = 64,
        [ItemType.Mining] = 20,
    };

    [Serializable]
    public class ItemInfo
    {
        public IItem Item;
        public int Count;

        public ItemInfo(IItem item, int count)
        {
            Item = item;
            Count = count;
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
            AddItem(item.Item,item.Count);
        _oldItems = null;
    }
    
    public void AddItem(IItem item, int amount)
    {
        //Находит первый предмент, схожий по item c поданным, и проверяет можно ли туда положить amount
        ItemInfo itm = _items.Find(x => x.Item == item && x.Count + amount <= _maxQuantity[x.Item.ItemType]);
        if (itm != null)
        {
            _items[_items.FindIndex(x => x == itm)] = new ItemInfo(item, amount + itm.Count);
            Render();
        }
        else if (_items.Count() < _maxSlots)
        {
            _items.Add(new ItemInfo(item,amount) );
            var cell = Instantiate(_inventoryCell, _transform);
            cell.Render(item, amount);
        }
    }
    
}
