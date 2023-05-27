using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Booster : MonoBehaviour
    {
        [SerializeField] protected float _duration;
        protected virtual void Take(){}
    }
}