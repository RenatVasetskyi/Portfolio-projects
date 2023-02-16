using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionAnimationsPlayer : MonoBehaviour
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
