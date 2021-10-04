using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellTemplate : MonoBehaviour
{
    [SerializeField] private Text _amountField;
    [SerializeField] private Image _icon;
    public void Render(IItem item, int amount = 1)
    {
        if (amount != 1)
            _amountField.text = amount.ToString();
        _icon.sprite = item.Icon;
    }
};