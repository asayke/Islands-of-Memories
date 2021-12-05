
using System;
using UnityEngine;
using static  MaxQuantity;

[Serializable]
[CreateAssetMenu(fileName = "ItemInfo", menuName = "ItemInfo")]
public class ItemInfo : ScriptableObject, IItemInfo
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected ItemType _itemType;
    [SerializeField] protected Type _type;
    [SerializeField] protected GameObject _gameObject;
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public ItemType ItemType => _itemType;
    //TODO Добавить в интерфейс
    public int MaxQuantity => Quantity[ItemType];
    public Type Type => _type;
    public GameObject GameObject => _gameObject;
}