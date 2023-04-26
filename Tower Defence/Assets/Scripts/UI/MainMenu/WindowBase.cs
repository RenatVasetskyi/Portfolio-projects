using UnityEngine;
using UnityEngine.UI;

public class WindowBase : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake() =>
        _button.onClick.AddListener(() => Destroy(gameObject));
}
