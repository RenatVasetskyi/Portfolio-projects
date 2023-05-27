using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}