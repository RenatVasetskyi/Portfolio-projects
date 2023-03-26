using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {      
        if (other.tag == Constants.EnemyTag)
        {
            if (_playerHealth.Hp > 0)
            {
                AudioManager.Instance.PlaySfx(SfxType.PlayerGetsDamage);
                EventManager.SendPlayerHpChanged(_damage);                
                Destroy(other.gameObject);
            }
            else
                EventManager.SendGameOver();         
        }
    }
}
