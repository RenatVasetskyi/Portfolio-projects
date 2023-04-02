using Tower;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour, IButtonSelection
{
    protected ButtonCreator _buttonCreator;

    public virtual void OnSelect()
    {
        _buttonCreator.ChangeSelection(gameObject);
    }

    public virtual void OnDeselect(GameObject button)
    {
        _buttonCreator.ChangeSelection(null);
    }

    protected void OnButtonClickHandler()
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

    private void Awake()
    {
        _buttonCreator = GetComponentInParent<ButtonCreator>();
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
    }
}
