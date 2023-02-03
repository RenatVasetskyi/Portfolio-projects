using UnityEngine;

[System.Serializable]
public class TowerData
{
    [SerializeField] private TowerType _towerType;
    [SerializeField] private GameObject _tower;

    public TowerType Type => _towerType;
    public GameObject Tower => _tower;
}
