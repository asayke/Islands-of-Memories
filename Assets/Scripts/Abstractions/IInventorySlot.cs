
public interface IInventorySlot
{
    bool IsFull { get; }
    bool IsEmpty { get; }
    int Amount { get; }
    IItem Item { get;}
    void Set(IItem item);
    void Clear();
}
