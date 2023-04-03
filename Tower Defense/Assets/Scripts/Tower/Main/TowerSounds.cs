using Audio;
using UnityEngine;

public class TowerSounds : MonoBehaviour, ISpawnTowerSounds
{   
    public void PlaySpawnSound()
    {
        AudioManager.Instance.PlaySfx(SfxType.TowerSpawned);
    }

    private void Start()
    {
        PlaySpawnSound();
    }   
}
