using UnityEngine;
using UnityEngine.UI;


public class TowerSelection : MonoBehaviour
{    
    [SerializeField] private Button _mageTowerButton;
    [SerializeField] private Button _cannonTowerButton;
    [SerializeField] private Button _megaTowerButton;
    [SerializeField] private Button _speedTowerButton;

    private TowerCreation _towerCreation;

    private Vector3 _startButtonSize = new Vector3(0.7f, 0.7f, 0.7f);
    private float _scaleDuration = 0.3f;

    private void Awake()
    {
        _mageTowerButton.onClick.AddListener(OnMageButtonClickHandler);
        _cannonTowerButton.onClick.AddListener(OnCannonButtonClickHandler);
        _megaTowerButton.onClick.AddListener(OnMegaButtonClickHandler);
        _speedTowerButton.onClick.AddListener(OnSpeedButtonClickHandler);

        _towerCreation = GetComponent<TowerCreation>();
    }

    private void OnMageButtonClickHandler()
    {
        LeanTween.scale(_mageTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

        _towerCreation.IsMageTowerButtonPressed = true;

        _towerCreation.IsCannonTowerButtonPressed = false;
        _towerCreation.IsMegaTowerButtonPressed = false;
        _towerCreation.IsSpeedTowerButtonPressed = false;
    }

    private void OnCannonButtonClickHandler()
    {
        LeanTween.scale(_cannonTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);

        _towerCreation.IsCannonTowerButtonPressed = true;

        _towerCreation.IsMageTowerButtonPressed = false;
        _towerCreation.IsMegaTowerButtonPressed = false;
        _towerCreation.IsSpeedTowerButtonPressed = false;
    }

    private void OnMegaButtonClickHandler()
    {
        LeanTween.scale(_megaTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_speedTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

        _towerCreation.IsMegaTowerButtonPressed = true;

        _towerCreation.IsCannonTowerButtonPressed = false;
        _towerCreation.IsMageTowerButtonPressed = false;
        _towerCreation.IsSpeedTowerButtonPressed = false;
    }

    private void OnSpeedButtonClickHandler()
    {
        LeanTween.scale(_speedTowerButton.gameObject, Vector3.one, _scaleDuration);

        LeanTween.scale(_megaTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_mageTowerButton.gameObject, _startButtonSize, _scaleDuration);
        LeanTween.scale(_cannonTowerButton.gameObject, _startButtonSize, _scaleDuration);

        _towerCreation.IsSpeedTowerButtonPressed = true;

        _towerCreation.IsMageTowerButtonPressed = false;
        _towerCreation.IsCannonTowerButtonPressed = false;
        _towerCreation.IsMegaTowerButtonPressed = false;
    }
}
