using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private Recipe _recipe;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<UIInventory>().Inventory;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            CraftItem(_recipe);
        }
    }

    private void CraftItem(IRecipe recipe)
    {
        for (var i = 0; i < recipe.Components.Count; ++i)
        {
            if (!_inventory.HasItem(recipe.Components[i], recipe.Amounts[i]))
            {
                Debug.Log($"Таких предметов для крафта нет!");
                return;
            }
        }
        for (var i = 0; i < recipe.Components.Count; ++i)
        {
            _inventory.Remove(recipe.Components[i].ItemType, recipe.Amounts[i]);
        }
        var itemToAdd = new Item(recipe.Craft);
        itemToAdd.State.Amount = recipe.Amount;
        _inventory.TryToAdd(itemToAdd);
    }
}