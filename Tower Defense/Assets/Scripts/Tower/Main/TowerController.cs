using UnityEngine;
using MyEvents;

namespace Tower
{
    public class TowerController : MonoBehaviour
    {
        private ITowerTrack _towerTrack;
        private IUpdateUpgradeText _upgaradeTowerText;

        private void Awake()
        {
            _towerTrack = GetComponent<ITowerTrack>();
            _upgaradeTowerText = GetComponent<IUpdateUpgradeText>();

            Events.OnUpgradeTowerTextUpdated.AddListener(_upgaradeTowerText.UpdateCurrentCharacteristicsText);
            Events.OnUpgradeTowerTextUpdated.AddListener(_upgaradeTowerText.UpdateUpgradeText);
        }

        private void Update()
        {
            _towerTrack.Track();
            _towerTrack.UpdateTarget();
        }
    }
}
