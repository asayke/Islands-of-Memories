using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine.Serialization;
using static Inventory;
[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject 
{
    [Header("Получаемые предметы:")]
    [SerializeField] private ItemInfo _received;
    [Header("Компоненты для Крафта:")]
    [SerializeField] private List<ItemInfo> _components;

    public List<ItemInfo> Components => _components;
    public ItemInfo Received => _received;
}

