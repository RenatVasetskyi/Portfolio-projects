using UnityEngine;
using UnityEngine.UI;

public class ButtonScaling : SelectTower
{
    private Vector3 _startSize = new Vector3(0.7f, 0.7f, 0.7f);
    private Vector3 _scaledSize = new Vector3(0.85f, 0.85f, 0.85f);
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
        SetStartSize();
    }

    private void SetStartSize()
    {
        for (int i = 0; i < _buttonCreator.SpawnedButtons.Count; i++)
        {
            _buttonCreator.SpawnedButtons[i].gameObject.transform.localScale = _startSize;
        }
    }
}
