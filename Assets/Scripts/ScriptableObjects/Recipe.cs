using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;
[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject 
{
    [Header("Получаемые предметы:")]
    [SerializeField] private SerializableDictionary<Item,uint> _item;
    [Header("Компоненты для Крафта:")]
    [SerializeField] private SerializableDictionary<Item,uint> _components;

    public SerializableDictionary<Item,uint> Components => _components;
}

