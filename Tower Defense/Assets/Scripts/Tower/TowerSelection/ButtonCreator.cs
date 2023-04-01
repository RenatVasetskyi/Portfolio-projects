using System.Collections.Generic;
using UnityEngine;

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
            SpawnedButtons[i].GetComponent<ButtonHolder>().TowerType = TowerSelectionButtons[i].TowerType;
            SpawnedButtons[i].GetComponent<ButtonHolder>().TowerPrefab = TowerSelectionButtons[i].TowerPrefab;
            SpawnedButtons[i].GetComponent<ButtonHolder>().Price = TowerSelectionButtons[i].Price;
            SpawnedButtons[i].GetComponent<ButtonHolder>().TowerModel = TowerSelectionButtons[i].TowerModel;
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
