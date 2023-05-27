using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public abstract class Booster : MonoBehaviour
    {
        [SerializeField] protected int _points;
        protected abstract void Take();
    }
}