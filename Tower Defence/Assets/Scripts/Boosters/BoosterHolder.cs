using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class BoosterHolder : MonoBehaviour
    {
        public List<BoosterButton> BoosterButtons { get; set; } = new();
    }
}