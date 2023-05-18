using UnityEngine;

namespace Assets.Scripts.Enemy.Main
{
    public class Enemy : MonoBehaviour
    {
        public int MaxHp { get; set; }
        public float Speed { get; set; }
        public int KillBonus { get; set; }
    }
}