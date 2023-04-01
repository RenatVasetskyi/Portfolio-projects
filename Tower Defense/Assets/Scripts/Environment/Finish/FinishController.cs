using UnityEngine;

public class FinishController : MonoBehaviour
{
    private IFinishDetector _finishDetector;

    private void Awake()
    {
        _finishDetector = GetComponent<IFinishDetector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _finishDetector.Detect(other);
    }
}
