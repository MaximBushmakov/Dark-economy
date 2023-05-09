using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;
using WorldSystem;

public class PopUp : MonoBehaviour
{
    private GameObject _dataObject;
    public void SetDataObject(GameObject obj)
    {
        _dataObject = obj;
    }

    private Product _product;
    public void SetProduct(Product product)
    {
        _product = product;
    }

    public void OnMouseDown()
    {
        int wisdom = GameData.Player.Wisdom;
        if (Input.GetMouseButton(1))
        {

            _dataObject.GetComponent<Text>().text =
                name + "\n" +
                "Цена: " + _product.GetCost(wisdom) + "\n" +
                "Качество: " + _product.GetQualityName() + "\n";
            _dataObject.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }
    }
}
