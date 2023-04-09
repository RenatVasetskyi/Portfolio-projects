using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CheckEnemyCollision(other);
    }

    private void CheckEnemyCollision(Collider other)
    {
        if (other.tag == Tags.EnemyTag)
        {
            Destroy(other.gameObject);
        }
    }
}
