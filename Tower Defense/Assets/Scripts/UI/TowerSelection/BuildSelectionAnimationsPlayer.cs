using UnityEngine;

public class BuildSelectionAnimationsPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayOpen()
    {
        _animator.SetTrigger("Open");
    }

    public void PlayClose() 
    {
        _animator.SetTrigger("Close");
    }
}
