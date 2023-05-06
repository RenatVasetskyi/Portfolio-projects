using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Boosters
{
    public class BoosterButton : MonoBehaviour
    {
        public BoosterType BoosterType;
        public bool IsActivated;

        [SerializeField] private Button _button;

        public void OffButton()
        {
            IsActivated = false;
            _button.interactable = false;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            if (IsActivated == true)
                IsActivated = false;
            else
                IsActivated = true;
        }
    }
}