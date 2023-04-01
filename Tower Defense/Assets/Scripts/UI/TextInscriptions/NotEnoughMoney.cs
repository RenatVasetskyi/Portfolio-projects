using TMPro;
using UnityEngine;

public class NotEnoughMoney : MonoBehaviour, IShowText
{
    [SerializeField] private TextMeshProUGUI _notEnoughMoneyText;

    private float _showTextScaleDuration = 0.1f;
    private float _hideTextScaleDuration = 0f;
    private float _textDisplacementDuration = 0.4f;

    private float _displacementY = 200f;

    private Vector3 _startPosition = new Vector3(0, 0, 0);

    public void Show()
    {
        LeanTween.scale(_notEnoughMoneyText.gameObject, Vector3.one, _showTextScaleDuration);
        LeanTween.moveLocalY(_notEnoughMoneyText.gameObject, _displacementY, _textDisplacementDuration).setOnComplete(Hide);
    }

    public void Hide()
    {
        LeanTween.scale(_notEnoughMoneyText.gameObject, Vector3.zero, _hideTextScaleDuration);
        _notEnoughMoneyText.gameObject.transform.localPosition = _startPosition;
    }

    private void Awake()
    {
        EventManager.NotEnoughMoney.AddListener(Show);
    }
}
