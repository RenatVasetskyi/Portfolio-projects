using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Enemy.Path
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