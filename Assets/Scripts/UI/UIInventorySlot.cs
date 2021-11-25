using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem _uiInventoryItem;

    public IInventorySlot Slot { get; private set; }

    private UIInventory _uiInventory;

    private void Awake()
    {
        _uiInventory = GetComponentInParent<UIInventory>();
    }
    
    public void Set(IInventorySlot slot)
    {
        Slot = slot;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherSlotUI.Slot;

        _uiInventory.Inventory.Transit(otherSlot, Slot);
        Render();
        otherSlotUI.Render();
    }
    
    public void Render()
    {
        if (Slot != null)
            _uiInventoryItem.Render(Slot);
    }
}