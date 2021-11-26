using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Recipe", menuName = "NewRecipe")]
public class Recipe : ScriptableObject, IRecipe
{
    [SerializeField] private List<InfoAmountPair> _components;
    [SerializeField] private List<InfoAmountPair> _craft;

    public List<InfoAmountPair> Components => _components;
    public List<InfoAmountPair> Craft => _craft;
    
}

[Serializable]
public class InfoAmountPair
{
    public ItemInfo ItemInfo;
    public int Amount;
}

//TODO перенести в отдельный файл, подумать над полями
public interface IRecipe
{
    List<InfoAmountPair> Components { get; }
    List<InfoAmountPair> Craft { get; }
}