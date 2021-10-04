using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Items/SimpleItem")]
public class Item : ScriptableObject, IItem
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Recipe _recipe;
    [SerializeField] private ItemType _itemType;
    
    public bool IsCrafting => _recipe != null;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Recipe Recipe => _recipe;
    public ItemType ItemType => _itemType;
}