using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy.Path
{
    public class Finish : MonoBehaviour
    {
        private IPlayerHpService _playerHpService;

        [Inject]
        public void Construct(IPlayerHpService playerHpService) =>
            _playerHpService = playerHpService;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tags.Enemy)
            {
                Destroy(other.gameObject);
                _playerHpService.TakeDamage(1);
            }
        }
    }
}