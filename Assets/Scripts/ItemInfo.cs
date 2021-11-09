
using System;
using UnityEngine;
using static  MaxQuantity;

[Serializable]
[CreateAssetMenu(fileName = "ItemInfo", menuName = "Create")]
public class ItemInfo : ScriptableObject, IItemInfo
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemType _itemType;


    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public ItemType ItemType => _itemType;
    public int MaxQuantity => Quantity[ItemType];
}