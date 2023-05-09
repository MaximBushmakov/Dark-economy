using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using WorldSystem;

namespace PlayerSystem
{
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

        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                int wisdom = GameData.Player.Wisdom;
                RectTransform rectTransform = _dataObject.GetComponent<RectTransform>();
                _dataObject.SetActive(true);
                _dataObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                    _product.GetVisibleType(wisdom) + "\n\n" +
                    _product.GetCost(wisdom) + " (c)\n\n" +
                    "Качество:\n" + _product.GetQualityName();
                rectTransform.anchoredPosition = Input.mousePosition / _dataObject.transform.parent.GetComponent<Canvas>().scaleFactor;

            }
            else if (Input.GetMouseButtonUp(1))
            {
                _dataObject.SetActive(false);
            }
        }
    }
}