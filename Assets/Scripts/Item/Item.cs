using System;
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
    public Item(IItemInfo info, int amount)
    {
        Info = info;
        State = new ItemState(amount);
    }

    protected Item()
    {
        throw new NotImplementedException();
    }

    public IItem Clone(int amount)
    {
        var cloned = new Item(Info);
        cloned.State.Amount = amount;
        return cloned;
    }
    

    //Сравнивает два предмета (Item) по типу.
    public int CompareTo(Item other)
    {
        return this.Info.Type.CompareTo(other.Info.Type);
    }

    public override string ToString()
    {
        return $"Name: {Info.Name}, Amount: {State.Amount}";
    }
}