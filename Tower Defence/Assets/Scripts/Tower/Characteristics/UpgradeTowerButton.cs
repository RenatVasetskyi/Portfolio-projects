using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Characteristics
{
    public class UpgradeTowerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TowerCharacteristics _towerCharacteristics;

        private void Awake() =>
            _button.onClick.AddListener(OnUpgradeTowerButtonClickHandler);

        private void OnUpgradeTowerButtonClickHandler() =>
            _towerCharacteristics.Upgrade();
    }
}