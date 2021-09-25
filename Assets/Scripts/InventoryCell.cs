using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Text _amountField;
    [SerializeField] private Image _icon;
    public void Render(IItem item, int amount)
    {
        if (amount != 1)
            _amountField.text = amount.ToString();
        _icon.sprite = item.Icon;
    }
    
    #region Moving cells
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
    #endregion
};

