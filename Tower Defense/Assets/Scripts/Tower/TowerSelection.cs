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
        LeanTween.scale(_mageTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

        IsMageTowerButtonPressed = true;

        IsCannonTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnCannonButtonClickHandler()
    {
        LeanTween.scale(_cannonTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);

        IsCannonTowerButtonPressed = true;

        IsMageTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnMegaButtonClickHandler()
    {
        LeanTween.scale(_megaTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

       IsMegaTowerButtonPressed = true;

        IsCannonTowerButtonPressed = false;
        IsMageTowerButtonPressed = false;
        IsSpeedTowerButtonPressed = false;
    }

    private void OnSpeedButtonClickHandler()
    {
        LeanTween.scale(_speedTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

        IsSpeedTowerButtonPressed = true;

        IsMageTowerButtonPressed = false;
        IsCannonTowerButtonPressed = false;
        IsMegaTowerButtonPressed = false;
    }
}
