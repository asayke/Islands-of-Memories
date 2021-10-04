using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Craft _craft;
    [SerializeField] private Recipe _recipe;
    [SerializeField] private Item _item1;
    [SerializeField] private Item _item2;
    [SerializeField] private Item _item3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventory.AddItem(_item1, 1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _inventory.AddItem(_item2, 1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            _inventory.AddItem(_item3, 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _craft.CreateItem(_recipe);
        }
    }
}


