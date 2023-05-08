using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventoryDrag : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    private static float _scale = 0;
    private RectTransform _rectTransform;

    public void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        if (_scale == 0)
        {
            Canvas canvas = GameObject.Find("/Canvas").GetComponent<Canvas>();
            _scale = canvas.scaleFactor;
        }
    }
    public void OnBeginDrag(PointerEventData e)
    {
        transform.SetParent(GameObject.Find("Canvas").transform);
    }
    public void OnDrag(PointerEventData e)
    {
        _rectTransform.anchoredPosition += e.delta / _scale;
    }
    public void OnEndDrag(PointerEventData e)
    {
        // transform.SetParent(GameObject.Find("Canvas").transform);
    }
}
