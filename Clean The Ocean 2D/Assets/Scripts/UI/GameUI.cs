using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    private GameObject _settingsPanel;
    
    private void Start()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClickHandler);      
    }
  
    private void OnSettingsButtonClickHandler()
    {
        LeanTween.scale(_settingsPanel, Vector3.one, 0.2f);
    }
}
