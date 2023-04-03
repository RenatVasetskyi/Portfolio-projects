using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    public class ButtonCreator : MonoBehaviour, ICreateButton, IInitialize
    {
        public List<TowerSelectionButton> TowerSelectionButtons;
        public GameObject SelectedButton;

        public List<GameObject> SpawnedButtons { get; private set; } = new List<GameObject>();

        public void Create()
        {
            for (int i = 0; i < TowerSelectionButtons.Count; i++)
            {
                GameObject button = Instantiate(TowerSelectionButtons[i].Button, transform);
                SpawnedButtons.Add(button);
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < SpawnedButtons.Count; i++)
            {
                SpawnedButtons[i].GetComponent<ButtonHolder>().TowerType = TowerSelectionButtons[i].Tower.TowerType;
                SpawnedButtons[i].GetComponent<ButtonHolder>().TowerPrefab = TowerSelectionButtons[i].Tower.TowerPrefab;              
                SpawnedButtons[i].GetComponent<ButtonHolder>().TowerModel = TowerSelectionButtons[i].Tower.TowerModel;
                SpawnedButtons[i].GetComponent<ButtonHolder>().Price = TowerSelectionButtons[i].Tower.Price;
            }
        }

        public void ChangeSelection(GameObject button)
        {
            SelectedButton = button;
        }

        private void Start()
        {
            Create();
            Initialize();
        }
    }
}
