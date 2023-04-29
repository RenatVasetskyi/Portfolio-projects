using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Architecture.States.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}