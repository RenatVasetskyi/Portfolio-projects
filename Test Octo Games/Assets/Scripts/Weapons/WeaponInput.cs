using System;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponInput : MonoBehaviour
    {
        public event Action OnLeftMouseButtonPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnLeftMouseButtonPressed?.Invoke();
            }
        }
    }
}