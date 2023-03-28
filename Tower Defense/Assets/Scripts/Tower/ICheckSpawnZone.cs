using UnityEngine;

public interface ICheckSpawnZone
{
    public RaycastHit CheckZone();
    public void ShowTower(RaycastHit hit);
    public void ChangeTowerColor();
}
