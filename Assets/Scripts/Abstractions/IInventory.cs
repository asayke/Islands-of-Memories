
using System.Collections.Generic;

public interface IInventory
{
    int Capacity { get; }
    
    bool IsFull { get; }

    void TryToAdd(IItem item);

    void Remove(Type type, int amount = 1);
    
    IItem GetItem(string name);
    
    IEnumerable<IItem> GetItems();
}