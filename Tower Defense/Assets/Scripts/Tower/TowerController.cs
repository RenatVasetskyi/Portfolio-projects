using UnityEngine;

public class TowerController : MonoBehaviour
{
    private ITowerTrack _towerTrack;

    private void Awake()
    {
        _towerTrack = GetComponent<ITowerTrack>();
    }

    private void Update()
    {
        _towerTrack.Track(); 
        _towerTrack.UpdateTarget();
    }
}
