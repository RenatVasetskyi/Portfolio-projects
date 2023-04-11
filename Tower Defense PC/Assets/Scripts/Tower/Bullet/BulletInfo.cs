using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBullet", menuName = "Create Bullet/Bullet")]
public class BulletInfo : ScriptableObject
{
    public GameObject Prefab;
    public int Damage;
    public int Speed;
}
