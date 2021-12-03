using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private ItemInfo _rock;
    [SerializeField] private ItemInfo _axe;
    [SerializeField] private GameObject _vecticalInventory;
    private UIInventorySlot[] _uiSlots;
    public Inventory Inventory;


    private void Awake()
    {
        _uiSlots = GetComponentsInChildren<UIInventorySlot>();
        Inventory = new Inventory(9);
        Inventory.InventoryStateChanged += OnInventoryStateChanged;
        SetupInventoryUI(Inventory);
    }

    private void OnInventoryStateChanged()
    {
        foreach (var slot in _uiSlots)
            slot.Render();
    }

    private void SetupInventoryUI(Inventory inventory)
    {
        var allSlots = inventory.GetSlots()?.ToList();
        var allSlotsCount = allSlots?.Count;
        for (int i = 0; i < allSlotsCount; ++i)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.Set(slot);
            uiSlot.Render();
        }
    }
}