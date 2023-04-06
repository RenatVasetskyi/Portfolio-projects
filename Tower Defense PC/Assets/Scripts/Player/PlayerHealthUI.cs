using TMPro;
using UnityEngine;
using Zenject;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPontsText;

    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        UpdateHealthPointsText();
    }

    private void UpdateHealthPointsText()
    {
        _healthPontsText.text = _playerHealth.HealthPoints.ToString();
    }
}
