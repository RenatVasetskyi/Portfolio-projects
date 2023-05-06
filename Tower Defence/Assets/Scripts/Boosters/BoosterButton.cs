using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Boosters
{
    public class BoosterButton : MonoBehaviour
    {
        public BoosterType BoosterType;
        public bool IsActivated;

        public Button Button;

        private void Awake() =>
            Button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            if (IsActivated == true)
                IsActivated = false;
            else
                IsActivated = true;
        }
    }
}