using UnityEngine;
using UnityEngine.UI;

namespace Tower
{
    public class ScaleButton : MonoBehaviour, IButtonScaling
    {
        private Vector3 _startSize = new Vector3(55f, 55f, 55f);
        private Vector3 _scaledSize = new Vector3(65f, 65f, 65f);
        private float _scaleDuration = 0.3f;

        private ButtonCreator _buttonCreator;

        public void OnSelect()
        {
            _buttonCreator.ChangeSelection(gameObject);
            LeanTween.scale(gameObject, _scaledSize, _scaleDuration);
        }

        public void OnDeselect(GameObject button)
        {
            _buttonCreator.ChangeSelection(null);
            LeanTween.scale(button, _startSize, _scaleDuration);
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
            _buttonCreator = GetComponentInParent<ButtonCreator>();

            for (int i = 0; i < _buttonCreator.SpawnedButtons.Count; i++)
            {
                _buttonCreator.SpawnedButtons[i].gameObject.transform.localScale = _startSize;
            }
        }

        private void OnButtonClickHandler()
        {
            if (_buttonCreator.SelectedButton == null)
            {
                OnSelect();
            }
            else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton != gameObject)
            {
                OnDeselect(_buttonCreator.SelectedButton);
                OnSelect();
            }
            else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton == gameObject)
            {
                OnDeselect(gameObject);
            }
        }
    }
}
