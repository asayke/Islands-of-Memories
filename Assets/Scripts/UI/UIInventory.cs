using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class UIInventory : MonoBehaviour
{
    [SerializeField] private ItemInfo _item1;
    [SerializeField] private ItemInfo _item2;
    [SerializeField] private GameObject _pausemenu;
    public UIInventorySlot[] _uiSlots;
    public Inventory Inventory;
    
    private void Awake()
    {
        _uiSlots = GetComponentsInChildren<UIInventorySlot>();
        Inventory = new Inventory(9);
        Inventory.InventoryStateChanged += OnInventoryStateChanged;
        SetupInventoryUI(Inventory);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
            Inventory.TryToAdd(new Item(_item1));
        if(Input.GetKeyDown(KeyCode.P))
            Inventory.TryToAdd(new Item(_item2));

        //Выбор предметов на q, одну штуку
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //TDOO убрать try catch
            try
            {
                var selectedSlot = _uiSlots?.FirstOrDefault(x => x.IsSelected);
                if (selectedSlot != null && !selectedSlot.Slot.IsEmpty)
                {
                    var item = selectedSlot.Slot.Item;
                    //TODO исправить как-то, а то в обьектах есть сама камера
                    var сhildren = GameObject.FindWithTag("MainCamera").gameObject.GetComponentsInChildren<Transform>();
                    var obj = сhildren[1];
                    obj.GetComponent<Rigidbody>().isKinematic = false;
                    obj.parent = null;
                    //TODO Изменить куда спавниться предмет.
                    obj.transform.position = GameObject.FindWithTag("DroppedPosition").transform.position;
                    Inventory.RemoveFromSlot(item.Info.Type,selectedSlot.Slot);
                }
            }
            catch
            {
            }
        }
        
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