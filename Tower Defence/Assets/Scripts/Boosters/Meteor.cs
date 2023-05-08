using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Meteor : MovableBooster
    {
        public event Action OnTargetReached;

        public override IEnumerator Move(Vector3 targetPosition)
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