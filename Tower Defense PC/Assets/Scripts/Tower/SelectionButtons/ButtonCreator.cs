using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ButtonCreator : MonoBehaviour, IInitializable
{
    public List<TowerSelectionButton> TowerSelectionButtons; 
    public List<GameObject> SpawnedButtons { get; private set; } = new List<GameObject>();
    public GameObject SelectedButton { get; private set; }

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
            SpawnedButtons[i].GetComponent<ButtonHolder>().Tower = TowerSelectionButtons[i].Tower;          
        }
    }

    public void ChangeSelection(GameObject button)
    {
        SelectedButton = button;
    }

    private void Awake()
    {
        Create();
        Initialize();
    }
}
