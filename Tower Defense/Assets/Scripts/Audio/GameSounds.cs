using UnityEngine;

public class GameSounds : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMusic(MusicType.Game);
    }

    private void Awake()
    {
        EventManager.EnemyDestroyed.AddListener(DestroyEnemySound);
    }

    private void DestroyEnemySound()
    {
        AudioManager.Instance.PlaySfx(SfxType.EnemyKilled);
    }
}
