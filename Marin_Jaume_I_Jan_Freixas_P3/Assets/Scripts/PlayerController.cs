using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private int IsWalkingHash;
    private int IsRunningHash;
    private int IsJumpingHash;
    private int IsBackwardsHash;

    public float Speed = 10;
    public float RunSpeed = 20;
    public float JumpSpeed = 3;
    public float SmoothRotation = 0.1f;

    public float LateralSpeed = 1;

    public Transform GroundChecker;
    public float groundSphereRadius = 0.1f;

    public LayerMask WhatIsGround;
    public LayerMask WhatIsIce;
    public LayerMask WhatIsWind;


    Vector3 _lastVelocity;
    bool _wasGrounded;

    CharacterController _characterController;
    InputController _inputController;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputController = GetComponent<InputController>();
        animator = GetComponentInChildren<Animator>();

        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsJumpingHash = Animator.StringToHash("IsJumping");
        IsBackwardsHash = Animator.StringToHash("IsBackwards");

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void Move()
    {
        Vector3 velocity = _lastVelocity;
        
        bool IsJumping = animator.GetBool(IsJumpingHash);
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool IsBackwards = animator.GetBool(IsBackwardsHash);

        Vector3 localInput = transform.right * _inputController.InputMove.x* LateralSpeed
            + transform.forward * _inputController.InputMove.y;

        float smothy = 1;
        if (!IsGrounded() && !IsWind())
            smothy = 0.01f;

        if (IsGrounded())
        {
            if (velocity.z < 0)
            {
                animator.SetBool(IsBackwardsHash, true);
                animator.SetBool(IsWalkingHash, false);
            }
            if (velocity.z > 0)
            {
                animator.SetBool(IsBackwardsHash, false);
                animator.SetBool(IsWalkingHash, true);
            }
            if (velocity.z == 0)
            {
                animator.SetBool(IsBackwardsHash, false);
                animator.SetBool(IsWalkingHash, false);
            }
        }

        if (ShouldJump())
        {
            velocity.y = JumpSpeed;
            {
                animator.SetBool(IsJumpingHash, true);
            }

        }

        if (justlanded())
        {
            animator.SetBool(IsJumpingHash, false);
        }

        _lastVelocity = velocity;

        _characterController.Move(velocity * Time.deltaTime);


        velocity.x = Mathf.Lerp(velocity.x, localInput.x * Speed, smothy);
        velocity.y = GetGravity();
        velocity.z = Mathf.Lerp(velocity.z, localInput.z * Speed, smothy);
        
        if (ShouldRun())
        {
            velocity.x = Mathf.Lerp(velocity.x, localInput.x * RunSpeed, smothy);
            velocity.y = GetGravity();
            velocity.z = Mathf.Lerp(velocity.z, localInput.z * RunSpeed, smothy);
        }

        _lastVelocity = velocity;

        _characterController.Move(velocity * Time.deltaTime);

        if (ShouldWind())
        {
            velocity.x = GetWind();
        }
        
        _lastVelocity = velocity;

        _characterController.Move(velocity * Time.deltaTime);

        if (velocity.magnitude > 0.01f)
        {
            var currentLook = transform.position + transform.forward;
            var lookPointTarget = transform.position + new Vector3(velocity.x, 0, velocity.z);
            var lookPoint = Vector3.Lerp(currentLook, lookPointTarget, SmoothRotation * Time.deltaTime);
            transform.LookAt(lookPoint);

        }
    }


    private bool ShouldJump()
    {
        return _inputController.Jumped && (IsGrounded()|| IsWind());
    }
    private bool ShouldWind()
    {
        return IsWind();
    }

    private bool ShouldRun()
    {
        return _inputController.Ran && (IsGrounded() || IsWind());
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(GroundChecker.position, groundSphereRadius, WhatIsGround);
    }
    private bool IsWind()
    {
        return Physics.CheckSphere(GroundChecker.position, groundSphereRadius, WhatIsWind);
    }


    private float GetGravity()
    {
        float currentVelocity = _lastVelocity.y;
        currentVelocity += Physics.gravity.y * Time.deltaTime;
        return currentVelocity;
    }

    private float GetWind()
    {
        float currentVelocity = _lastVelocity.x;
        currentVelocity += 5000 * Time.deltaTime;
        return currentVelocity;
    }
    bool justlanded()
    {
        bool isGrounded = IsGrounded();

        bool landed = isGrounded && !_wasGrounded;

        _wasGrounded = isGrounded;
        return landed;
    }
}
