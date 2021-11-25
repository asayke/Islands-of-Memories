using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEditor.VersionControl;
using UnityEngine;

public class Item : IItem, IComparable<Item>
{
    public IItemInfo Info { get; }
    public IItemState State { get; }

    public Item(IItemInfo info)
    {
        Info = info;
        State = new ItemState();
    }
    
    public IItem Clone(int amount)
    {
        var cloned = new Item(Info);
        cloned.State.Amount = amount;
        return cloned;
    }

    public GameObject GameObject { get; }
    
    //Сравнивает два предмета (Item) по типу.
    public int CompareTo(Item other)
    {
        return this.Info.ItemType.CompareTo(other.Info.ItemType);
    }

    public override string ToString()
    {
        return $"Name: {Info.Name}, Amount: {State.Amount}";
    }
}