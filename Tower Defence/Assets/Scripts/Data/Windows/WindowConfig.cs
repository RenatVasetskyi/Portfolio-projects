using System;
using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Data.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId Id;
        public GameObject Prefab;
    }
}