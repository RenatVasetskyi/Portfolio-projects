using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildTowerView : MonoBehaviour
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

    [SerializeField] private TextMeshProUGUI _towerDescription;

    [SerializeField] private Image _towerDescriptionBackground;

    [SerializeField] private LayerMask _towerPlace;
    [SerializeField] private LayerMask _environment;

    [SerializeField] private Camera _camera;

    private float _maxRayDistance = 120f; 

    private void Start()
    {
        _mageTowerButton.onClick.AddListener(OnMageTowerButtonClickHandler);
        _cannonTowerButton.onClick.AddListener(OnCannonTowerButtonClickHandler);
        _megaTowerButton.onClick.AddListener(OnMegaTowerButtonClickHandler);
        _speedTowerButton.onClick.AddListener(OnSpeedTowerButtonClickHandler);
        _checkMark.onClick.AddListener(OnCheckMarkButtonClickHandler);      
    }

    private void LateUpdate()
    {
        OpenBuildViewWithTouch();
        HideBuildViewWithTouch();
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

    private void HideBuildView()
    {
        _buildView.SetActive(false);
        ResetSelectionView();
    }

    private void OnMageTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Mage);      

        _cannonTowerImage.gameObject.SetActive(true);
        _megaTowerImage.gameObject.SetActive(true);
        _speedTowerImage.gameObject.SetActive(true);
    }

    private void OnCannonTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Cannon);

        _mageTowerImage.gameObject.SetActive(true);
        _megaTowerImage.gameObject.SetActive(true);
        _speedTowerImage.gameObject.SetActive(true);
    }

    private void OnMegaTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Mega);

        _mageTowerImage.gameObject.SetActive(true);
        _cannonTowerImage.gameObject.SetActive(true);
        _speedTowerImage.gameObject.SetActive(true);
    }

    private void OnSpeedTowerButtonClickHandler()
    {
        ViewingTheTower(TowerType.Speed);

        _mageTowerImage.gameObject.SetActive(true);
        _cannonTowerImage.gameObject.SetActive(true);
        _megaTowerImage.gameObject.SetActive(true);
    }

    private void OnCheckMarkButtonClickHandler()
    {
        HideBuildView();
        //Tower creation method
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
                _towerDescription.text = $"<size=22><color=#CDF537>Mage</color></size><size=16><color=#F0E6B9>\nThis tower shoots crystals and deals a lot of damage." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {100} </color><color=#94BA47>\nDamage:</color><color=red> {12} </color>";
                break;
            case TowerType.Cannon:
                _cannonTowerImage.gameObject.SetActive(false);              
                _checkMark.gameObject.SetActive(true);                
                _checkMark.transform.position = _cannonTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescription.text = $"<size=22><color=#CDF537>Cannon</color></size><size=16><color=#F0E6B9>\nThis tower shoots projectiles and has a low speed." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {80} </color><color=#94BA47>\nDamage:</color><color=red> {10} </color>";
                break;
            case TowerType.Mega:
                _megaTowerImage.gameObject.SetActive(false);                
                _checkMark.gameObject.SetActive(true);
                _checkMark.transform.position = _megaTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescription.text = $"<size=22><color=#CDF537>Mega</color></size><size=16><color=#F0E6B9>\nThis tower shoots projectiles and deals a lot of damage." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {120} </color><color=#94BA47>\nDamage:</color><color=red> {14} </color>";
                break;
            case TowerType.Speed:
                _speedTowerImage.gameObject.SetActive(false);
                _checkMark.gameObject.SetActive(true);
                _checkMark.gameObject.transform.position = _speedTowerImage.transform.position;
                _towerDescriptionBackground.gameObject.SetActive(true);
                _towerDescription.text = $"<size=22><color=#CDF537>Speed</color></size><size=16><color=#F0E6B9>\nThis tower shoots small projectiles but has fast speed." +
                    $"</color></size><color=#94BA47>\nPrice:</color><color=yellow> {90} </color><color=#94BA47>\nDamage:</color><color=red> {6} </color>";
                break;
        }
    }

    private void OpenBuildViewWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, _maxRayDistance, _towerPlace))
                {
                    ResetSelectionView();
                    _buildView.SetActive(true);
                    _buildView.transform.position = touch.position;
                }
            }
        }
    }

    private void HideBuildViewWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, _maxRayDistance, _towerPlace))
                    return;

                if (Physics.Raycast(ray, _maxRayDistance, _environment))
                {                             
                    _buildView.SetActive(false);
                    ResetSelectionView();
                }
            }
        }
    }
}
