
using System.Collections.Generic;

public interface IInventory
{
    int Capacity { get; }
    
    bool IsFull { get; }

    void TryToAdd(IItem item);

    void Remove(ItemType itemType, int amount = 1);
    
    IItem GetItem(string name);
    
    IEnumerable<IItem> GetItems();
}