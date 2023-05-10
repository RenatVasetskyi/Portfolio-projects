using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerModelColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _modelMaterial;

        private Color32 _lightGreenColor = new Color32(144, 217, 144, 255);
        private Color32 _lightRedColor = new Color32(229, 113, 109, 255);

        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        private void OnMouseEnter()
        {
            if (_uiFactory.TowerSelection?.SelectedButton != null)
                ChangeColor(_lightRedColor);
        }

        private void OnMouseExit()
        {
            if (_uiFactory.TowerSelection?.SelectedButton != null)
                ChangeColor(_lightGreenColor);
        }

        private void ChangeColor(Color32 color) =>
            _modelMaterial.color = color;
    }
}