using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Car.UI.Buttons
{
    public class SelectableButton : Button
    {
        public new bool IsPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            IsPressed = IsPressed();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            IsPressed = IsPressed();
        }
    }
}