using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IUIFactory
    {
        GameObject CreateWindow();
    }
}