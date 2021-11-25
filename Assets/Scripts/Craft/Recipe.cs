using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Recipe", menuName = "NewRecipe")]
public class Recipe : ScriptableObject, IRecipe
{
    [SerializeField] private List<ItemInfo> _components;
    [SerializeField] private int[] _amounts;
    [SerializeField] private ItemInfo _craft;
    [SerializeField] private int _amount;

    public List<ItemInfo> Components => _components;
    public int[] Amounts => _amounts;
    public ItemInfo Craft => _craft;
    public int Amount => _amount;
}

//TODO перенести в отдельный файл, подумать над полями
public interface IRecipe
{
    List<ItemInfo> Components { get; }
    int[] Amounts { get; }
    ItemInfo Craft { get; }
    int Amount { get; }
}