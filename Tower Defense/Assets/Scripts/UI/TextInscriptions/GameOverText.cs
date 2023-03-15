using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private float _moveDuration = 0.75f;
    [SerializeField] private LeanTweenType _showEaseType;

    private void Awake()
    {
        EventManager.GameOver.AddListener(ShowGameOverText);
    }

    private void ShowGameOverText()
    {      
        LeanTween.scale(_gameOverText.gameObject, Vector3.one, _moveDuration).setEase(_showEaseType).setOnComplete(HideGameOverText);
    }

    private void HideGameOverText()
    {     
        LeanTween.scale(_gameOverText.gameObject, Vector3.zero, _moveDuration);
    }
}
