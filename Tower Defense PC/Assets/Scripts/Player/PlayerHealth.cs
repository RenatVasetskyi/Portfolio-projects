using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints { get; private set; }

    [Inject]
    private void Construct(LevelSettinsHolder levelSettinsHolder)
    {
        HealthPoints = levelSettinsHolder.PlayerHealthPoints;
    }
}
