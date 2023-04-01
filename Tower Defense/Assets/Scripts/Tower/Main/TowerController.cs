using UnityEngine;

public class TowerController : MonoBehaviour
{
    private ITowerTrack _towerTrack;
    private IUpdateUpgradeText _upgaradeTowerText;
    
    private void Awake()
    {
        _towerTrack = GetComponent<ITowerTrack>();
        _upgaradeTowerText = GetComponent<IUpdateUpgradeText>();

        EventManager.UpgradeTowerTextUpdate.AddListener(_upgaradeTowerText.UpdateCurrentCharacteristicsText);
        EventManager.UpgradeTowerTextUpdate.AddListener(_upgaradeTowerText.UpdateUpgradeText);
    }

    private void Update()
    {
        _towerTrack.Track(); 
        _towerTrack.UpdateTarget();
    }
}
