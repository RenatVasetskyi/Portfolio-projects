using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Characteristics
{
    public class CloseTowerCharacteristicsWindow : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TowerCharacteristicsDisplayer _towerCharacteristicsDisplayer;

        private void Awake() => 
            _button.onClick.AddListener(OnCloseButtonClickHandler);

        private void OnCloseButtonClickHandler() =>
            _towerCharacteristicsDisplayer.CloseTowerCharacteristicsWindow();
    }
}