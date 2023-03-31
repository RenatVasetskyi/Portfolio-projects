using UnityEngine;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour, IButtonScaling
{
    private Vector3 _startSize = new Vector3(40f, 40f, 40f);
    private Vector3 _scaledSize = new Vector3(50f, 50f, 50f);
    private float _scaleDuration = 0.3f;

    private ButtonCreator _buttonCreator;

    public void OnSelect()
    {      
        LeanTween.scale(gameObject, _scaledSize, _scaleDuration);
        _buttonCreator.ChangeSelection(gameObject);              
    }

    public void OnDeselect()
    {
        LeanTween.scale(gameObject, _startSize, _scaleDuration);
        _buttonCreator.SelectedButton = null;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
        _buttonCreator = GetComponentInParent<ButtonCreator>();
    }

    private void OnButtonClickHandler()
    {
        if (_buttonCreator.SelectedButton == null)
        {
            OnSelect();
        }          
        else
        {
            OnDeselect();
        }            
    }
}
