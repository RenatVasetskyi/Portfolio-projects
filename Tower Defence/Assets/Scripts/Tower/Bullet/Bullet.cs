using Assets.Scripts.Data.Levels;
using Assets.Scripts.Tower.Selection;
using UnityEngine;

namespace Assets.Scripts.Tower.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private TowerType _towerType;

        [SerializeField] private AllLevelsSettings _levelsSettings;

        public int BulletSpeed { get; private set; }
        public int Damage { get; set; }
        
        private void Awake() => 
            Initialize();

        private void Initialize()
        {
            foreach (LevelSettings level in _levelsSettings.Levels)
            {
                foreach (TowerSelectionButton button in level.TowerSelectionButtons.Buttons)
                {
                    if (button.Tower.TowerType == _towerType)
                    {
                        BulletSpeed = button.Tower.Bullet.Damage;
                        Damage = button.Tower.Bullet.Damage;
                    }
                }
            }
        }
    }
}