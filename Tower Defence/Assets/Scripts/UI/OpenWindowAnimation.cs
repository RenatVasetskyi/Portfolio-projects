using UnityEngine;

namespace Assets.Scripts.UI
{
    public class OpenWindowAnimation : MonoBehaviour
    {
        [SerializeField] private LeanTweenType _easeType;
        [SerializeField] private float _endPoint;
        [SerializeField] private float _duration;

        private void Start() => PlayOpen();

        private void PlayOpen()
        {
            LeanTween.moveLocalY(gameObject, _endPoint, _duration).setEase(_easeType);
        }
    }
}