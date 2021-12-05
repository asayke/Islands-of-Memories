using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _amountText;
    private IItem Item { get; set; }

    private void Clear()
    {
        _icon.gameObject.SetActive(false);
        _amountText.gameObject.SetActive(false);
    }

    public void Render(IInventorySlot slot)
    {
        if (slot.IsEmpty)
        {
            Clear();
            return;
        }
        Item = slot.Item;
        _icon.sprite = Item.Info.Icon;
        _icon.gameObject.SetActive(true);
        var isAmountSuit = slot.Amount > 1;
        _amountText.gameObject.SetActive(isAmountSuit);
        if (isAmountSuit)
            _amountText.text = $"{slot.Amount}";
    }
}