using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Booster : MonoBehaviour
    {
        public event Action OnTargetReached;

        public int Damage;
        public int Speed;

        public IEnumerator Move(Vector3 targetPosition)
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
                yield return null;
            }

            OnTargetReached.Invoke();
        }
    }
}