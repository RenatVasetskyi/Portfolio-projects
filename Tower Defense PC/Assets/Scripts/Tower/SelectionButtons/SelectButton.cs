using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour, ISelectable
{
    protected ButtonCreator _buttonCreator;
    protected ButtonHolder _buttonHolder;

    public virtual void OnSelect()
    {
        _buttonCreator.ChangeSelection(_buttonHolder);
    }

    public virtual void OnDeselect(ButtonHolder button)
    {
        _buttonCreator.ChangeSelection(null);
    }

    protected void OnButtonClickHandler()
    {
        if (_buttonCreator.SelectedButton == null)
        {
            OnSelect();
        }
        else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton.Tower.TowerType != _buttonHolder.Tower.TowerType)
        {
            OnDeselect(_buttonHolder);
            OnSelect();
        }
        else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton.Tower.TowerType == _buttonHolder.Tower.TowerType)
        {
            OnDeselect(_buttonHolder);
        }
    }

    private void Awake()
    {
        _buttonCreator = GetComponentInParent<ButtonCreator>();
        _buttonHolder = gameObject.GetComponent<ButtonHolder>();
        GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
    }
}

