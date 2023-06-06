using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _shotDistance;

        [SerializeField] private WeaponInput _weaponInput;

        private void OnEnable() =>
            _weaponInput.OnLeftMouseButtonPressed += Shoot;

        private void Shoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, _shotDistance))
                Hit();
        }

        private void Hit()
        {
            Debug.Log("Hit");
        }
    }
}
