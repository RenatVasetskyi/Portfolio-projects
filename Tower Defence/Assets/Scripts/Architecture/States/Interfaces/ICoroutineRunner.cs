using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Architecture.Main
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}