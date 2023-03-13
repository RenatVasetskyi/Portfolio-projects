using System.Collections;
using UnityEngine;

namespace UI
{
    public class ExitButtonDetector : MonoBehaviour
    {
        private float _delay = 1f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Constants.PlayerTag)
            {
                StartCoroutine(Exit());
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }

        private IEnumerator Exit()
        {
            yield return new WaitForSeconds(_delay);
            Application.Quit();
        }
    }
}
