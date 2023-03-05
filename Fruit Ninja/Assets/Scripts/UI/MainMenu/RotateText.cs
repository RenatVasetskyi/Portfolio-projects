using UnityEngine;

public class RotateText : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
        transform.Translate(new Vector3(0.6f, 0, 0) * Time.deltaTime);
    }
}
