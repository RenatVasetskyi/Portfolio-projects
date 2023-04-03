using Audio;
using UnityEngine;

namespace Enemy
{
    public class EnemySounds : MonoBehaviour, IDestroyEnemySound
    {
        public void PlayDestroySound()
        {
            AudioManager.Instance.PlaySfx(SfxType.EnemyKilled);
        }

        private void OnDestroy()
        {
            PlayDestroySound();
        }
    }
}
