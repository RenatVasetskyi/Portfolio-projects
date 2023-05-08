using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public abstract class MovableBooster : MonoBehaviour
    {
        public int Speed;
        public abstract IEnumerator Move(Vector3 targetPosition);
    }
}