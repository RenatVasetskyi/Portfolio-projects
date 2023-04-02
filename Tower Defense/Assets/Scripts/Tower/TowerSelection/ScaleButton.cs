using UnityEngine;
using UnityEngine.UI;

namespace Tower
{
    public class ScaleButton : ButtonSelection
    {
        private Vector3 _startSize = new Vector3(55f, 55f, 55f);
        private Vector3 _scaledSize = new Vector3(65f, 65f, 65f);
        private float _scaleDuration = 0.3f;

        public override void OnSelect()
        {          
            LeanTween.scale(gameObject, _scaledSize, _scaleDuration);
        }

        public override void OnDeselect(GameObject button)
        {           
            LeanTween.scale(button, _startSize, _scaleDuration);
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);

            for (int i = 0; i < _buttonCreator.SpawnedButtons.Count; i++)
            {
                _buttonCreator.SpawnedButtons[i].gameObject.transform.localScale = _startSize;
            }           
        }
    }
}
