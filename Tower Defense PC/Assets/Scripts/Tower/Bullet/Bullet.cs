using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IInitializable
{   
    [SerializeField] private TowerInfo _towerInfo;   
 
    public int BulletSpeed { get; private set; }
    public int Damage { get; set; }

    public void Initialize()
    {
        BulletSpeed = _towerInfo.Bullet.Speed;
    }

    private void Awake()
    {
        Initialize();
    }   
}
