using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public abstract class SimpleBooster : MonoBehaviour
    {
        [SerializeField] protected int _points;
        protected abstract void Take();
    }
}