using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour
{
    [SerializeField] private GameObject _buildView;

    [SerializeField] private Button _mageTowerButton;
    [SerializeField] private Button _cannonTowerButton;
    [SerializeField] private Button _megaTowerButton;
    [SerializeField] private Button _speedTowerButton;

    [SerializeField] private Image _mageTowerImage;
    [SerializeField] private Image _cannonTowerImage;
    [SerializeField] private Image _megaTowerImage;
    [SerializeField] private Image _speedTowerImage;

    [SerializeField] private Button _checkMark;

    [SerializeField] private Image _towerDescriptionBackground;

    [SerializeField] private TextMeshProUGUI _towerDescription;

    private float _descriptionShift = 400;
   
    private void Start()
    {       
        _mageTowerButton.onClick.AddListener(OnMageTowerButtonClickHandler);
        _cannonTowerButton.onClick.AddListener(OnCannonTowerButtonClickHandler);
        _megaTowerButton.onClick.AddListener(OnMegaTowerButtonClickHandler);
        _speedTowerButton.onClick.AddListener(OnSpeedTowerButtonClickHandler);
        _checkMark.onClick.AddListener(OnCheckMarkButtonClickHandler);
    }

    protected void ResetSelectionView()
    {
        _checkMark.gameObject.SetActive(false);
        _mageTowerImage.gameObject.SetActive(true);
        _cannonTowerImage.gameObject.SetActive(true);
        _megaTowerImage.gameObject.SetActive(true);
        _speedTowerImage.gameObject.SetActive(true);
        _towerDescriptionBackground.gameObject.SetActive(false);
    }

    private void OnMageTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Mage);
    }

    private void OnCannonTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Cannon);
    }

    private void OnMegaTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Mega);
    }

    private void OnSpeedTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Speed);
    }

    private void OnCheckMarkButtonClickHandler()
    {
        ResetSelectionView();

    }

    private void ViewingTheTower(TowerType towerType)
    {            
        switch (towerType)
        {
            case TowerType.Mage:              
                _mageTowerImage.gameObject.SetActive(false);
                _checkMark.gameObject.SetActive(true);
                _checkMark.transform.position = _mageTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescriptionBackground.transform.position = new Vector2(_mageTowerImage.transform.position.x + _descriptionShift, _mageTowerImage.transform.position.y);
                _towerDescription.text = $"<size=22><color=#CDF537>Mage</color></size><size=16><color=#F0E6B9>\nThis tower shoots crystals and deals a lot of damage." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {100} </color><color=#94BA47>\nDamage:</color><color=red> {12} </color>";               
                break;
            case TowerType.Cannon:
                _cannonTowerImage.gameObject.SetActive(false);
                _checkMark.gameObject.SetActive(true);
                _towerDescriptionBackground.gameObject.SetActive(true);
                _checkMark.transform.position = _cannonTowerImage.transform.position;
                _towerDescriptionBackground.transform.position = new Vector2(_cannonTowerImage.transform.position.x - _descriptionShift, _cannonTowerImage.transform.position.y);
                _towerDescription.text = $"<size=22><color=#CDF537>Cannon</color></size><size=16><color=#F0E6B9>\nThis tower shoots projectiles and has a low speed." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {80} </color><color=#94BA47>\nDamage:</color><color=red> {10} </color>";
                break;
            case TowerType.Mega:
                _megaTowerImage.gameObject.SetActive(false);
                _checkMark.gameObject.SetActive(true);
                _checkMark.transform.position = _megaTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescriptionBackground.transform.position = new Vector2(_megaTowerImage.transform.position.x - _descriptionShift, _megaTowerImage.transform.position.y);
                _towerDescription.text = $"<size=22><color=#CDF537>Mega</color></size><size=16><color=#F0E6B9>\nThis tower shoots projectiles and deals a lot of damage." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {120} </color><color=#94BA47>\nDamage:</color><color=red> {14} </color>";
                break;
            case TowerType.Speed:
                _speedTowerImage.gameObject.SetActive(false);
                _checkMark.gameObject.SetActive(true);
                _checkMark.gameObject.transform.position = _speedTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescriptionBackground.transform.position = new Vector2(_speedTowerImage.transform.position.x + _descriptionShift, _speedTowerImage.transform.position.y);
                _towerDescription.text = $"<size=22><color=#CDF537>Speed</color></size><size=16><color=#F0E6B9>\nThis tower shoots small projectiles but has fast speed." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {90} </color><color=#94BA47>\nDamage:</color><color=red> {6} </color>";
                break;
        }
    }  
}
