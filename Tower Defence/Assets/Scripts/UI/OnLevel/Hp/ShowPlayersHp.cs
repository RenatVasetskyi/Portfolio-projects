using Assets.Scripts.Architecture.Services.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.Hp
{
    public class ShowPlayersHp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hpText;

        private IPlayerHpService _playerHpService;

        [Inject]
        public void Construct(IPlayerHpService playerHpService) =>
            _playerHpService = playerHpService;

        private void Start() =>
            UpdatePlayersHp();

        private void UpdatePlayersHp() =>
            _hpText.text = _playerHpService.Hp.ToString();
    }
}