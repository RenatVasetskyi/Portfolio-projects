using UnityEngine;
using UnityEngine.UI;
using Audio;

namespace UI
{
    public class ScreenAppearance : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;

        private float _disappearDuration = 1.5f;
        private float _appearScreenDuration = 1f;

        private void Awake()
        {
            Appear();
            Events.OnBombExploded.AddListener(Disappear);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Constants.PlayerTag)
            {
                AudioManager.Instance.PlaySfx(SfxType.Explosion);
                Events.SendOnBombExploded();
            }
        }

        private void Appear()
        {
            LeanTween.color(_fadeImage.rectTransform, Color.clear, _appearScreenDuration).setOnComplete(OffFadeImage);
        }

        private void OffFadeImage()
        {
            _fadeImage.gameObject.SetActive(false);
        }

        private void OnFadeImage()
        {
            _fadeImage.gameObject.SetActive(true);
        }

        private void Disappear()
        {
            OnFadeImage();
            LeanTween.color(_fadeImage.rectTransform, Color.white, _disappearDuration).setOnComplete(Appear);
        }
    }
}
