using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDragSell : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    private static float _scale = 0;
    private RectTransform _rectTransform;
    private Transform _startObject;

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
        if (e.button == PointerEventData.InputButton.Left)
        {
            _startObject ??= transform.parent;
            transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }
    public void OnDrag(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
        {
            _rectTransform.anchoredPosition += e.delta / _scale;
        }
    }
    public void OnEndDrag(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var colliders = Physics2D.OverlapPointAll(position);

            if (colliders.Count() == 2 && colliders[1].name == "Cell(Clone)" && colliders[1].transform.parent.parent.parent.parent.parent.name == "Trader part")
            {
                _rectTransform.SetParent(colliders[1].transform);
                _rectTransform.anchoredPosition = new(0, 0);
            }
            else
            {
                transform.SetParent(_startObject);
                _rectTransform.anchoredPosition = new(0, 0);
            }
        }
    }
}
