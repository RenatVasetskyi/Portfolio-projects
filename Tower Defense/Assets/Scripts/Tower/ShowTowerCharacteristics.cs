using TMPro;
using UnityEngine;
using System;

public class ShowTowerCharacteristics : MonoBehaviour, IUpgradeCanvas, IUpdateUpgradeText
{   
    [SerializeField] private TextMeshProUGUI _currentDamageText;
    [SerializeField] private TextMeshProUGUI _currentFireSpeedText;
    [SerializeField] private TextMeshProUGUI _currentAttackRangeText;

    [SerializeField] private Canvas _towerCanvas;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _fireSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;

    [SerializeField] private TextMeshProUGUI _upgradePriceText;

    [SerializeField] private Vector3 _canvasScale;

    private float _canvasScaleDuration = 0.3f;  

    private bool _isUpgrageCanvasOpen = false;

    private UpgradeTowerCharacteristics _upgradeTower;

    public void UpdateUpgradeText()
    {
        _damageText.text = _upgradeTower.Damage.ToString() + $"<color=green> + {Math.Round(_upgradeTower.Damage * (_upgradeTower.DamageIncreasing - 1), 1)} </color>";
        _fireSpeedText.text = _upgradeTower.FireSpeed.ToString() + $"<color=green> + {_upgradeTower.FireSpeedIncreasing} </color>";
        _attackRangeText.text = _upgradeTower.AttackRange.ToString() + $"<color=green> + {Math.Round(_upgradeTower.AttackRange * (_upgradeTower.AttackRangeIncreasing - 1), 1)} </color>";
        _upgradePriceText.text = $"Cost {Math.Round(_upgradeTower.UpgradePrice, 1)}";
    }

    public void UpdateCurrentCharacteristicsText()
    {
        _currentDamageText.text = _upgradeTower.Damage.ToString();
        _currentFireSpeedText.text = _upgradeTower.FireSpeed.ToString();
        _currentAttackRangeText.text = _upgradeTower.AttackRange.ToString();
    }

    public void OpenUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(true);
        LeanTween.scale(_towerCanvas.gameObject, _canvasScale, _canvasScaleDuration);
    }

    public void CloseUpgradeCanvas()
    {
        LeanTween.scale(_towerCanvas.gameObject, Vector3.zero, _canvasScaleDuration).setOnComplete(OffUpgradeCanvas);
    }

    public void OffUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        _upgradeTower = GetComponent<UpgradeTowerCharacteristics>();

        UpdateCurrentCharacteristicsText();
        UpdateUpgradeText();

        _towerCanvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        _towerCanvas.gameObject.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDown()
    {
        if (_isUpgrageCanvasOpen == false)
        {
            _isUpgrageCanvasOpen = true;
            OpenUpgradeCanvas();
        }
        else
        {
            _isUpgrageCanvasOpen = false;
            CloseUpgradeCanvas();
        }
    }
}
