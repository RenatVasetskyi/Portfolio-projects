using UnityEngine;

public class TowerSpawnEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _spawnEffect;   

    private void Start()
    {
        _spawnEffect.Play();
    } 
}