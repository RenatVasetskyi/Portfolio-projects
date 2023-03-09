using UnityEngine;
using Audio;

public class FruitBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _whole;
    [SerializeField] private GameObject _sliced;

    private Rigidbody _fruitRigidbody;
    private Collider _fruitCollider;
    private ParticleSystem _juiceParticleSystem;

    private void Awake()
    {
        _fruitRigidbody = GetComponent<Rigidbody>();
        _fruitCollider = GetComponent<Collider>();
        _juiceParticleSystem = GetComponentInChildren<ParticleSystem>();      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.Direction, blade.transform.position, blade.SliceForce);
        }
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        AudioManager.Instance.PlaySfx(SfxType.Slice);

        Events.SendOnFruitSliced();

        _whole.SetActive(false);
        _sliced.SetActive(true);
        _fruitCollider.enabled = false;

        _juiceParticleSystem.Play();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = _sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = _fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
}
