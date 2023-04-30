using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.EnemyPath
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tags.Enemy)
            {
                Destroy(other.gameObject);
            }
        }
    }
}