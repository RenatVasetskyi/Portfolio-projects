using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBullet", menuName = "Create Bullet/Bullet")]
public class BulletInfo : ScriptableObject
{
    public int Damage;
    public int Speed;
}
