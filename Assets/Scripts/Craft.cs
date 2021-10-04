using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;


public class Craft : MonoBehaviour
{
    [SerializeField] private CellTemplate _cellTemplate;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<Recipe> _recipes;
    
    private void OnEnable()
    {
       // _inventory =  //TODO Когда появится персонаж
       foreach (var x in _recipes)
       {
           var cell = Instantiate(_cellTemplate, transform);
           cell.Render(x.Received.Item);
       }
    }

    //Проверяет можно ли создать на данный момент предмет
    private bool IsCraftAllowed(Recipe recipe)
    {
        if (recipe.Components.Count == 0) 
            return false;
        foreach (var comp in recipe.Components)
        {
            print($"{_inventory._items.FindAll(x => x.Item == comp.Item).Select(x => x.Count).Sum()}/{comp.Count}");
            if (_inventory._items.FindAll(x => x.Item == comp.Item).Select(x => x.Count).Sum() < comp.Count)
                return false;
        }
        return true;
    }
    
    public void CreateItem(Recipe recipe)
    {
        if (IsCraftAllowed(recipe))
        { 
            _inventory.AddItem(recipe.Received.Item,recipe.Received.Count);
            foreach (var del in recipe.Components)
                _inventory.DeleteItem(del.Item, del.Count);
        }
        else print($"Нет нужных предметов для крафта.");
    }
}