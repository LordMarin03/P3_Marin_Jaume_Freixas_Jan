using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private int IsWalkingHash;
    private int IsRunningHash;
    private int IsEstasMort;
    public InputController _input;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsEstasMort = Animator.StringToHash("EstasMort");
    }

    void Update()
    {
        animator.SetBool(IsRunningHash, _input.Ran);
    }
}

