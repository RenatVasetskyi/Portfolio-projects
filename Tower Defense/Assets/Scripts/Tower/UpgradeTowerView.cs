using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTowerView : UpgradeTower
{   
    [SerializeField] private Canvas _towerCanvas;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _fireSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;

    [SerializeField] private TextMeshProUGUI _upgradePriceText;

    [SerializeField] private Button _upgradeButton;

    [SerializeField] private Button _closeCanvasButton;
   
    private float _scaleDuration = 0.3f;

    private void Awake()
    {     
        _towerCanvas.worldCamera = Camera.main;
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClickHandler);
        _closeCanvasButton.onClick.AddListener(OnCloseCanvasButtonClickHandler);
        EventManager.UpgradeTowerTextUpdate.AddListener(UpdateUpgradeText);

        UpdateUpgradeText();
    }

    private void Update()
    {
        _towerCanvas.gameObject.transform.LookAt(Camera.main.transform);        
    }

    private void OnMouseDown()
    {
        _towerCanvas.enabled = true;
        LeanTween.scale(_towerCanvas.gameObject, Vector3.one, _scaleDuration);
    }

    private void OnUpgradeButtonClickHandler()
    {
        Upgrade();
    }

    private void OnCloseCanvasButtonClickHandler()
    {
        LeanTween.scale(_towerCanvas.gameObject, Vector3.zero, _scaleDuration);      
    }

    private void UpdateUpgradeText()
    {
        _damageText.text = _damage.ToString() + $"<color=green> + {_damage * (_damageIncreasing - 1)} </color>";
        _fireSpeedText.text = _fireSpeed.ToString() + $"<color=green> - {_fireSpeed * (_fireSpeedIncreasing - 1)} </color>";
        _attackRangeText.text = _attackRange.ToString() + $"<color=green> + {_attackRange * (_attackRangeIncreasing - 1)} </color>";
        _upgradePriceText.text = $"Cost {_upgradePrice}";
    }
}
