using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    [SerializeField] private List<TowerData> _towerDataList = new List<TowerData>();    

    public TowerData GetTower(TowerType towerType)
    {
        var result = _towerDataList.Find(data => data.Type == towerType);
        return result;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }   
}
