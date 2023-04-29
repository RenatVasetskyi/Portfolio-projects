using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public class WindowBase : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake() =>
            _button.onClick.AddListener(() => Destroy(gameObject));
    }
}
