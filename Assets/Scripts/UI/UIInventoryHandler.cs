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
            print("Typed 1");
            Select(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Typed 2");
            Select(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Typed 3");
            Select(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("Typed 4");
            Select(4);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("Typed 5");
            Select(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            print("Typed 6");
            Select(6);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            print("Typed 7");
            Select(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            print("Typed 8");
            Select(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            print("Typed 9");
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
        foreach (var x in _uiInventory._uiSlots)
        {
            if (x != _uiInventory._uiSlots[n - 1])
                x.GetComponent<Outline>().enabled = false;
        }
    }
}