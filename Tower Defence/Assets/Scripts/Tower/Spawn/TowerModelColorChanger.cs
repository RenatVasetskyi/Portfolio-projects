using UnityEngine;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerModelColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _modelMaterial;

        private Color32 _lightGreenColor = new Color32(144, 217, 144, 255);
        private Color32 _lightRedColor = new Color32(229, 113, 109, 255);

        private void OnMouseEnter() =>
            ChangeColor(_lightRedColor);

        private void OnMouseExit() =>
            ChangeColor(_lightGreenColor);

        private void ChangeColor(Color32 color) =>
            _modelMaterial.color = color;
    }
}