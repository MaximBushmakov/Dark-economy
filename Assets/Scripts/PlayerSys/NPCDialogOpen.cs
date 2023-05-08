using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WorldSystem;

namespace PlayerSystem
{
    public class NPCDialogOpen : MonoBehaviour
    {
        private GameObject _interactionButtons;

        public void SetActionButtons(GameObject interactionButtons)
        {
            _interactionButtons = interactionButtons;
        }

        private Image _image;
        protected void Start()
        {
            _image = GetComponent<Image>();
        }

        protected void OnMouseEnter()
        {
            _image.color = new Color(0.9f, 0.9f, 0.9f, 1);
        }

        protected void OnMouseExit()
        {
            _image.color = Color.white;
        }

        public void OnMouseDown()
        {
            if (_interactionButtons.activeSelf)
            {
                _interactionButtons.SetActive(false);
            }
            else
            {
                _interactionButtons.SetActive(true);
                GameData.CurTrader = TimeSystem.GetInstance()
                    .GetLocation(GameData.Player.Location)
                    .FindNPCInSublocation(GameData.Player.Sublocation)
                    .Find(npc => npc.GetName() == name);
            }
        }
    }

}
