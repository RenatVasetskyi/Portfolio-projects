using Assets.Scripts.Architecture.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WindowId _windowId;

        private IWindowService _windowService;

        [Inject]
        public void Construct(IWindowService windowService) =>
            _windowService = windowService;

        private void Awake() =>
            _button.onClick.AddListener(Open);

        private void Open()
        {
            if (_windowService == null)
            {
                Debug.Log("A");
            }

            _windowService.Open(_windowId);
        }
    }
}