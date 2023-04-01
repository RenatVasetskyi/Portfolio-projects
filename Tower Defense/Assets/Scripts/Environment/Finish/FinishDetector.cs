using UnityEngine;
using Audio;
using Data;
using Events;
using Vitality;

namespace Environment
{
    public class FinishDetector : MonoBehaviour, IFinishDetector
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private int _damageToPlayer = 1;

        public void Detect(Collider collider)
        {
            if (collider.tag == Constants.EnemyTag)
            {
                if (_playerHealth.Hp > 1)
                {
                    AudioManager.Instance.PlaySfx(SfxType.PlayerGetsDamage);
                    EventManager.SendPlayerHpChanged(_damageToPlayer);
                    Destroy(collider.gameObject);
                }
                else
                {
                    EventManager.SendPlayerHpChanged(_damageToPlayer);
                    EventManager.SendGameOver();
                }
            }
        }
    }
}
