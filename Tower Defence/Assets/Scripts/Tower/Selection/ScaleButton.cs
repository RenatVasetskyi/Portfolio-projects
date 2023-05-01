using UnityEngine;

namespace Assets.Scripts.Tower.Selection
{
    public class ScaleButton : MonoBehaviour
    {
        [SerializeField] private SelectTowerButton _button;

        private Vector3 _startSize = new Vector3(0.7f, 0.7f, 0.7f);
        private Vector3 _scaledSize = new Vector3(0.85f, 0.85f, 0.85f);
        private float _scaleDuration = 0.3f;

        public void SetStartSize() =>
            gameObject.transform.localScale = _startSize;

        private void Awake()
        {
            _button.OnButtonSelected += Select;
            _button.OnButtonDeselected += Deselect;
        }

        private void Select() =>
            LeanTween.scale(gameObject, _scaledSize, _scaleDuration);

        private void Deselect(TowerSelectionButtonHolder button) =>
            LeanTween.scale(button.gameObject, _startSize, _scaleDuration);
    }
}