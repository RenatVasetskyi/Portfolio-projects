using System.Collections.Generic;
using Assets.Scripts.Tower.Selection;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories
{
    public class TowerSelection : MonoBehaviour
    {
        public List<TowerSelectionButtonHolder> Buttons { get; set; } = new();
        public TowerSelectionButtonHolder SelectedButton { get; private set; }

        private void Start() =>
            Init();

        public void ChangeSelection(TowerSelectionButtonHolder button) =>
            SelectedButton = button;

        private void Init()
        {
            foreach (TowerSelectionButtonHolder button in GetComponentsInChildren<TowerSelectionButtonHolder>())
                Buttons.Add(button);
        }
    }
}