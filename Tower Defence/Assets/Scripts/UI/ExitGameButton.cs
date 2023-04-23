using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ExitGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake() =>
            _button.onClick.AddListener(Quit);

        private void Quit() => 
            Application.Quit();
    }
}