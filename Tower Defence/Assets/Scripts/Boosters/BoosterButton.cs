using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Boosters
{
    public class BoosterButton : MonoBehaviour
    {
        public BoosterType BoosterType;
        public Booster Booster;
        public bool IsActivated;

        [SerializeField] private Button _button;

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