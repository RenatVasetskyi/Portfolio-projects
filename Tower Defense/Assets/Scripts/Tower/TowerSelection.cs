using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour
{
    public bool IsMageTowerButtonPressed = false;
    public bool IsCannonTowerButtonPressed = false;
    public bool IsMegaTowerButtonPressed = false;
    public bool IsSpeedTowerButtonPressed = false;

    [SerializeField] private Button _mageTowerButton;
    [SerializeField] private Button _cannonTowerButton;
    [SerializeField] private Button _megaTowerButton;
    [SerializeField] private Button _speedTowerButton;

    private Vector3 _startButtonSize = new Vector3(0.7f, 0.7f, 0.7f);
    private float _scaleDuration = 0.3f;

    private void Awake()
    {
        _mageTowerButton.onClick.AddListener(OnMageButtonClickHandler);
        _cannonTowerButton.onClick.AddListener(OnCannonButtonClickHandler);
        _megaTowerButton.onClick.AddListener(OnMegaButtonClickHandler);
        _speedTowerButton.onClick.AddListener(OnSpeedButtonClickHandler);
    }

    private void OnMageButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);

        if (IsMageTowerButtonPressed == false)
        {
            IsMageTowerButtonPressed = true;

            LeanTween.scale(_mageTowerButton.gameObject, Vector3.one, _scaleDuration);

            LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);
        }
        else
        {
            IsMageTowerButtonPressed = false;
            LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);          
        }

        IsCannonTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnCannonButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);

        if (IsCannonTowerButtonPressed == false)
        {
            IsCannonTowerButtonPressed = true;

            LeanTween.scale(_cannonTowerButton.gameObject, Vector3.one, _scaleDuration);

            LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);          
            LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        }
        else
        {
            IsCannonTowerButtonPressed = false;
            LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);
        }
             
        IsMageTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnMegaButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);

        if (IsMegaTowerButtonPressed == false)
        {
            IsMegaTowerButtonPressed = true;

            LeanTween.scale(_megaTowerButton.gameObject, Vector3.one, _scaleDuration);

            LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);          
        }
        else
        {
            IsMegaTowerButtonPressed = false;
            LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        }

        IsCannonTowerButtonPressed = false;
        IsMageTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnSpeedButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);

        if (IsSpeedTowerButtonPressed == false)
        {
            IsSpeedTowerButtonPressed = true;

            LeanTween.scale(_speedTowerButton.gameObject, Vector3.one, _scaleDuration);

            LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);
            LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);                   
        }
        else
        {
            IsSpeedTowerButtonPressed = false;
            LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        }
        
        IsMageTowerButtonPressed = false;
        IsCannonTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
    }
}
