using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIInventoryHandler : MonoBehaviour
{
    private Panels _panels;
    private UIInventory _uiInventory;
    private UIInventorySlot _selectingSlot;
    
    private void Awake()
    {
        _panels = GetComponent<Panels>();
        _uiInventory = GetComponent<UIInventory>();
    }
    
    private void Update()
    {
        //TODO Исправить все это... ужасно просто....)))
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Select(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Select(4);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Select(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Select(6);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Select(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Select(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Select(9);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //TODO убрать try catch
            try
            {
                _selectingSlot = _uiInventory._uiSlots.FirstOrDefault(x => x.IsSelected);
                if (_selectingSlot != null && !_selectingSlot.Slot.IsEmpty)
                {
                    if (_selectingSlot.Slot.Item?.Info?.ItemType == ItemType.Food)
                    {
                        EatItem(_selectingSlot.Slot.Item);
                        _uiInventory.Inventory.RemoveFromSlot(_selectingSlot.Slot.Item.Info.Type,_selectingSlot.Slot);
                    }
                }
            }
            catch
            {
            }
        }
    }


    private void EatItem(IItem item)
    {
        if (item.Info is EatItemInfo itemInfo)
        {
            _panels.HealthBar.IncreaseValue(itemInfo.HealthValue);
            _panels.ThistBar.IncreaseValue(itemInfo.ThirstValue);
            _panels.MealBar.IncreaseValue(itemInfo.MealValue);
            _panels.EnergyBar.IncreaseValue(itemInfo.EnergyValue);
            
        }
    }

    //Выбирает слот по номеру, который нужно выбрать.
    private void Select(int n)
    {
        if (n <= 0)
            throw new ArgumentOutOfRangeException();
        var outline = _uiInventory._uiSlots[n - 1].GetComponent<Outline>();
        outline.enabled = !outline.IsActive();
        _uiInventory._uiSlots[n - 1].IsSelected = outline.enabled;
        foreach (var x in _uiInventory._uiSlots)
        {
            if (x != _uiInventory._uiSlots[n - 1])
            {
                x.GetComponent<Outline>().enabled = false;
                x.IsSelected = false;
            }
        }
    }
}