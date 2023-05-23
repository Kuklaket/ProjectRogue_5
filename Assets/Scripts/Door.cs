using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void OpenDoor()
    {
        _animator.SetBool("IsOpen", true);
    }
}
