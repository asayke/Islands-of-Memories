using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform _cameraTransform;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private Transform _inventoryTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        //_cameraTransform = FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<Camera>().transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _rectTransform.parent.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
        _inventoryTransform = _rectTransform.parent.parent.transform;
        _rectTransform.parent.parent = _canvas.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Деление на _canvas.scaleFactor нужно чтобы нивелировать разницу между References Resolution и Пользовательским
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    private bool In(RectTransform originalParent)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!In((RectTransform) _inventoryTransform))
        {
            var uiSlot = GetComponentInParent<UIInventorySlot>();
            var uiInvetory = GetComponentInParent<UIInventory>();
            //TODO Переименовать _uiSlots в UISlots
            var item = uiSlot.Slot.Item;
            for (int i = 0; i < item.State.Amount; i++)
            {
                var obj = Instantiate(item.Info.GameObject);  
                //TODO Изменить куда спавнится предмет.
                obj.transform.position = new Vector3(1, 1, 1);
            }
            uiInvetory.Inventory.RemoveFromSlot(item.Info.Type,uiSlot.Slot,item.State.Amount);
        }
        _rectTransform.parent.parent = _inventoryTransform;
        _rectTransform.parent.SetAsFirstSibling();
        _rectTransform.localPosition = new Vector3(0, 0, 0);
        _canvasGroup.blocksRaycasts = true;
    }
}