using UnityEngine;

public class ChangeTowerModelColor : MonoBehaviour
{   
    [SerializeField] private Material _modelMaterial;

    private ShowTowerModel _showTowerModel;

    private void Awake()
    {
        _showTowerModel = GetComponent<ShowTowerModel>();
        _showTowerModel.OnTowerZoneChanged += ChangeColor;       
    }

    private void OnDestroy()
    {
        _showTowerModel.OnTowerZoneChanged -= ChangeColor;
    }

    private void ChangeColor(Color color)
    {
        _modelMaterial.color = color;     
    }  
}
