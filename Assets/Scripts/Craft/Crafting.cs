using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private Recipe _recipe;
    [SerializeField] private GameObject craftmenu;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<UIInventory>().Inventory;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     craftmenu.SetActive(!craftmenu.activeSelf);
        //     Cursor.lockState = craftmenu.activeSelf ?  CursorLockMode.None : CursorLockMode.Locked ;
        //     Cursor.visible = craftmenu.activeSelf;
        // }
    }

    public void CraftAxe()
    {
        CraftItem(_recipe);
    }
    
    private void CraftItem(IRecipe recipe)
    {
        for (var i = 0; i < recipe.Components.Count; ++i)
        {
            var amountInfoPair = recipe.Components[i];
            if (!_inventory.HasItem(amountInfoPair.ItemInfo, amountInfoPair.Amount))
            {
                Debug.Log($"Таких предметов для крафта нет!");
                return;
            }
        }
        if (!_inventory.IsAllOccupied)
        {
            for (var i = 0; i < recipe.Components.Count; ++i)
            {
                var amountInfoPair = recipe.Components[i];
                _inventory.Remove(amountInfoPair.ItemInfo.Type, amountInfoPair.Amount);
            }
        
            for (int i = 0; i < recipe.Craft.Count; i++)
            {
                var itemToCraft = recipe.Craft[i];
                //TODO Обзяательно переделать.
                for (int j = 0; j < itemToCraft.Amount; j++)
                {
                    var itemToAdd = new Item(itemToCraft.ItemInfo);
                    _inventory.TryToAdd(itemToAdd);
                }
            }
        }
    }
}