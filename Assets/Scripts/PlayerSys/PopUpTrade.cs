using UnityEngine;
using UnityEngine.UI;
using WorldSystem;

namespace PlayerSystem
{
    public class PopUpTrade : MonoBehaviour
    {
        private GameObject _dataObject;
        public void SetDataObject(GameObject obj)
        {
            _dataObject = obj;
        }

        public Price Price { get; set; }

        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                int wisdom = GameData.Player.Wisdom;
                RectTransform rectTransform = _dataObject.GetComponent<RectTransform>();
                _dataObject.SetActive(true);
                _dataObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                    Price.GetProduct().GetVisibleType(wisdom) + "\n\n" +
                    Price.GetViewPrice() + " (c)\n\n" +
                    "Качество:\n" + Price.GetProduct().GetQualityName();
                rectTransform.anchoredPosition = Input.mousePosition / _dataObject.transform.parent.GetComponent<Canvas>().scaleFactor;

            }
            else if (Input.GetMouseButtonUp(1))
            {
                _dataObject.SetActive(false);
            }
        }
    }
}