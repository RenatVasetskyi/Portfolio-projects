using UnityEngine;

public interface ICheckSpawnZone
{
    public RaycastHit CheckZone();
    public void ChangeTowerColor();
}
