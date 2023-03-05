using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAppearance : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    private float _duration = 1f;

    private void Start()
    {
        Appear();
    }

    private void Appear()
    {
        LeanTween.color(_fadeImage.rectTransform, Color.clear, _duration).setOnComplete(OffFadeImage);             
    } 

    private void OffFadeImage()
    {
        _fadeImage.gameObject.SetActive(false);
    }
}
