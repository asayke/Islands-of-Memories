using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private Transform _inventoryTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
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

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.parent.parent = _inventoryTransform;
        _rectTransform.parent.SetAsFirstSibling();
        _rectTransform.localPosition = new Vector3(0, 0, 0);
        _canvasGroup.blocksRaycasts = true;
    }
}