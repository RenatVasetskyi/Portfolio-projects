using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Events.OnBombExploded.AddListener(PlayShake);
    }

    private void PlayShake()
    {
        _animator.SetTrigger("Shake");
    }

    private void PlayDefault()
    {
        _animator.SetBool("Default", true);
    }
}
