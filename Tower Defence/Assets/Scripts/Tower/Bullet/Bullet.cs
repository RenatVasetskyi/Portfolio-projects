using Assets.Scripts.Tower.Characteristics;
using UnityEngine;

namespace Assets.Scripts.Tower.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private TowerType _towerType;

        private TowerCharacteristics _towerCharacteristics;

        public int BulletSpeed { get; private set; }
        public int Damage { get; set; }
        
        private void Awake() => 
            Initialize();

        private void Initialize()
        {
            _towerCharacteristics = GetComponentInParent<TowerCharacteristics>();
            BulletSpeed = _towerCharacteristics.BulletSpeed;
            Damage = _towerCharacteristics.Damage;
        }
    }
}