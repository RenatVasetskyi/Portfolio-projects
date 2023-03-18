using TMPro;
using UnityEngine;

public class TowerCharacteristics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentDamageText;
    [SerializeField] private TextMeshProUGUI _currentFireSpeedText;
    [SerializeField] private TextMeshProUGUI _currentAttackRangeText;

    [SerializeField] protected float _damage = 25f;
    [SerializeField] protected float _fireSpeed = 1f;
    [SerializeField] protected float _attackRange = 10f;

    private void Awake()
    {
        UpdateCurrentCharacteristicsText();
        EventManager.UpgradeTowerTextUpdate.AddListener(UpdateCurrentCharacteristicsText);
    }

    private void UpdateCurrentCharacteristicsText()
    {
        _currentDamageText.text = _damage.ToString();
        _currentFireSpeedText.text = _fireSpeed.ToString();
        _currentAttackRangeText.text = _attackRange.ToString();
    }
}
