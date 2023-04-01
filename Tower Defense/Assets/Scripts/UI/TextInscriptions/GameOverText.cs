using TMPro;
using UnityEngine;
using Events;

namespace UI
{
    public class GameOverText : MonoBehaviour, IShowText
    {
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private float _moveDuration = 0.75f;
        [SerializeField] private LeanTweenType _showEaseType;

        public void Show()
        {
            LeanTween.scale(_gameOverText.gameObject, Vector3.one, _moveDuration).setEase(_showEaseType).setOnComplete(Hide);
        }

        public void Hide()
        {
            LeanTween.scale(_gameOverText.gameObject, Vector3.zero, _moveDuration);
        }

        private void Awake()
        {
            EventManager.GameOver.AddListener(Show);
        }
    }
}
