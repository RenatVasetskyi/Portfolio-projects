using UnityEngine;
using UnityEngine.UI;

public class ScreenAppearance : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
   
    private float _closeScreenDuration = 1.5f;
    private float _openScreenDuration = 0.7f;

    private void Awake()
    {
        Appear();
        Events.OnBombExploded.AddListener(CloseScreen);
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
        LeanTween.color(_fadeImage.rectTransform, Color.clear, _closeScreenDuration).setOnComplete(OffFadeImage);             
    } 

    private void OffFadeImage()
    {
        _fadeImage.gameObject.SetActive(false);
    }

    private void OnFadeImage()
    {
        _fadeImage.gameObject.SetActive(true);
    }

    private void CloseScreen()
    {
        OnFadeImage();
        LeanTween.color(_fadeImage.rectTransform, Color.white, _closeScreenDuration).setOnComplete(OpenScreen);
    }

    private void OpenScreen()
    {
        LeanTween.color(_fadeImage.rectTransform, Color.clear, _openScreenDuration).setOnComplete(OffFadeImage);
    }
}
