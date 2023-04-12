using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour, ISelectable
{
    protected ButtonHolder _buttonHolder;
    private ButtonCreator _buttonCreator;

    public virtual void Select()
    {
        _buttonCreator.ChangeSelection(_buttonHolder);
    }

    public virtual void Deselect(ButtonHolder button)
    {
        _buttonCreator.ChangeSelection(null);
    }

    private void OnButtonClickHandler()
    {
        if (_buttonCreator.SelectedButton == null)
        {
            Select();
        }
        else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton.Tower.TowerType != _buttonHolder.Tower.TowerType)
        {
            Deselect(_buttonHolder);
            Select();
        }
        else if (_buttonCreator.SelectedButton != null & _buttonCreator.SelectedButton.Tower.TowerType == _buttonHolder.Tower.TowerType)
        {
            Deselect(_buttonHolder);
        }
    }

    private void Awake()
    {
        _buttonCreator = GetComponentInParent<ButtonCreator>();
        _buttonHolder = gameObject.GetComponent<ButtonHolder>();
        GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
    }
}

