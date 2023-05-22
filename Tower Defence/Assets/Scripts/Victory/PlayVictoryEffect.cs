using UnityEngine;

namespace Assets.Scripts.Victory
{
    public class PlayVictoryEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        private UnityEngine.Camera _camera;
        private Vector3 _spawnOffset = new Vector3(0, -20, 20);

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
            PlayEffect();
        }

        private void PlayEffect()
        { 
            ParticleSystem effect = Instantiate(_effect, CalculateSpawnPosition(), Quaternion.identity, null);
            effect.transform.rotation = CalculateSpawnRotation();
            effect.Play();
        }

        private Quaternion CalculateSpawnRotation() => 
            Quaternion.Euler(-_camera.transform.rotation.eulerAngles.x - 40, _camera.transform.rotation.eulerAngles.y, _camera.transform.rotation.eulerAngles.z);

        private Vector3 CalculateSpawnPosition() => 
            new Vector3(_camera.transform.position.x, _camera.transform.position.y,
                _camera.transform.position.z) + _spawnOffset;
    }
}