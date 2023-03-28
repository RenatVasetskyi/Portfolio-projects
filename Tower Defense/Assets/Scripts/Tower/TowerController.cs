using UnityEngine;

public class TowerController : MonoBehaviour
{
    private ITowerTrack _towerTrack;
    private IUpgaradeTower _upgaradeTower;
    
    private void Awake()
    {
        _towerTrack = GetComponent<ITowerTrack>();
        _upgaradeTower = GetComponent<IUpgaradeTower>();

        EventManager.UpgradeTowerTextUpdate.AddListener(_upgaradeTower.UpdateCurrentCharacteristicsText);
        EventManager.UpgradeTowerTextUpdate.AddListener(_upgaradeTower.UpdateUpgradeText);
    }

    private void Update()
    {
        _towerTrack.Track(); 
        _towerTrack.UpdateTarget();
    }
}
