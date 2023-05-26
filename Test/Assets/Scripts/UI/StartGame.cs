using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StartGame : MonoBehaviour
    {
        public event Action OnGameStarted;

        [SerializeField] private Image _countdown;

        [SerializeField] private Sprite _oneSecond;
        [SerializeField] private Sprite _twoSeconds;
        [SerializeField] private Sprite _start;

        private float _delay = 1;

        private void Awake() =>
            StartCoroutine(ShowCountdown());

        private IEnumerator ShowCountdown()
        {
            yield return new WaitForSeconds(_delay);
            _countdown.sprite = _twoSeconds;
            yield return new WaitForSeconds(_delay);
            _countdown.sprite = _oneSecond;
            yield return new WaitForSeconds(_delay);
            _countdown.sprite = _start;
            yield return new WaitForSeconds(_delay);
            OnGameStarted?.Invoke();
            Destroy(gameObject);
        }
    }
}