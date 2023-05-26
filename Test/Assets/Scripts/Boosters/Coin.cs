using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _points;

        private ICoinService _coinService;

        private void Awake() =>
            _coinService = AllServices.Container.Single<ICoinService>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            Take();
            Destroy(gameObject);
        }

        private void Take() =>
            _coinService.GetBonus(_points);
    }
}