using UnityEngine;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerModelColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _modelMaterial;

        private void OnMouseEnter() =>
            ChangeColor(Color.red);

        private void OnMouseExit() =>
            ChangeColor(Color.green);

        private void ChangeColor(Color color) =>
            _modelMaterial.color = color;
    }
}