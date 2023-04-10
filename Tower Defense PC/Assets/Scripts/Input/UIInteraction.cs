using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class UIInteraction : MonoBehaviour
{
    public List<RaycastResult> ClickResult;

    private GraphicRaycaster ui_raycaster;
    private PointerEventData _clickData;

    private PlayerInput _input;

    [Inject]
    private void Construct(PlayerInput input)
    {
        _input = input;
    }

    private void Start()
    {
        ui_raycaster = GetComponent<Canvas>().GetComponent<GraphicRaycaster>();
        _clickData = new PointerEventData(EventSystem.current);
        ClickResult = new List<RaycastResult>();
        _input.Player.GetPreesLeftMouseButton.performed += context => GetUIElements();
    }

    private void OnDestroy()
    {
        _input.Player.GetPreesLeftMouseButton.performed -= context => GetUIElements();
    }

    private void GetUIElements()
    {
        _clickData.position = Mouse.current.position.ReadValue();
        ClickResult.Clear();

        ui_raycaster.Raycast(_clickData, ClickResult);     
    }
}
