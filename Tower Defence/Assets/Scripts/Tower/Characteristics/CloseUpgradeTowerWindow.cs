using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Characteristics
{
    public class CloseUpgradeTowerWindow : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UpgradeTowerWindow _upgradeTowerWindow;

        //private void Awake() => 
        //    _button.onClick.AddListener(OnCloseButtonClickHandler);

        //private void OnCloseButtonClickHandler() =>
        //    _upgradeTowerWindow.CloseWindow();
    }
}