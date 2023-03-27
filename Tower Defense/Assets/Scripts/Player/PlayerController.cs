using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<IPlayerHealth>();
        EventManager.PlayerHpChanged.AddListener(_playerHealth.ReducePlayerHp);
    }
}
