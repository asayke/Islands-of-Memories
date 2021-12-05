using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIInventoryHandler : MonoBehaviour
{
    private UIInventory _uiInventory;

    private void Awake()
    {
        _uiInventory = GetComponent<UIInventory>();
    }
    
    private void Update()
    {
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