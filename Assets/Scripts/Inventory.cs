using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using System.Linq;
using ExtensionMethods;
using NUnit.Framework;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCell;
    [SerializeField] private Transform _transform;
    [SerializeField] private SerializableKeyValuePairList<Item,int> _items;
    private SerializableKeyValuePairList<Item,int> _oldItems;
    
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
    
    private void OnEnable()
    {
        Render();
    }
    private void Render()
    {
        foreach (Transform child in _transform)
            Destroy(child.gameObject);
        (_items, _oldItems) = (new SerializableKeyValuePairList<Item,int>(), _items);
        foreach (var item in _oldItems)
            AddItem(item.Key,item.Value);
        _oldItems = null;
    }
    
    public void AddItem(Item item, int amount)
    {
        if (_items.TryGetItemIndex(item, out int index) && _items[index].Value + amount <= _maxQuantity[_items[index].Key.ItemType])
        {
            _items[index] = new SerializableKeyValuePair<Item, int>(item, amount + _items[index].Value);  
            Render();
        }
        else
        {
            _items.Add(new SerializableKeyValuePair<Item, int>(item, amount));
            var cell = Instantiate(_inventoryCell, _transform);
            cell.Render(item, amount);
        }
    }
}
