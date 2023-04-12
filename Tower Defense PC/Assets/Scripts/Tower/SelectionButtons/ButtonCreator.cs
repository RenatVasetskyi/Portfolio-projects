using System.Collections.Generic;
using UnityEngine;

public class ButtonCreator : MonoBehaviour
{
    public List<TowerSelectionButton> TowerSelectionButtons;
    public ButtonHolder SelectedButton { get; private set; }

    public void ChangeSelection(ButtonHolder button)
    {
        SelectedButton = button;
    }

    private void Awake()
    {
        Create();
    }
    
    private void Create()
    {
        for (int i = 0; i < TowerSelectionButtons.Count; i++)
        {
            GameObject button = Instantiate(TowerSelectionButtons[i].Button, transform);
            Initialize(button, i);
        }
    }
    
    private void Initialize(GameObject button, int i)
    {
        button.GetComponent<ButtonHolder>().Tower = TowerSelectionButtons[i].Tower;
    }
}
