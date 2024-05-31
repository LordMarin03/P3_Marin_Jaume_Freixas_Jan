using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private Vector2 _inputMovement;
    public Vector2 InputMove { get { return _inputMovement; } }

    private bool _jumped;
    public bool Jumped { get { return _jumped; } }


    private bool _ran;
    public bool Ran { get { return _ran; } }

    private void LateUpdate()
    {
        _jumped = false;
    }
    void OnMove(InputValue input)
    {
        _inputMovement = input.Get<Vector2>();
    }
    void OnJump()
    {
        _jumped = true;
    }


    void OnRunStart()
    {
        _ran = true;
    }
    void OnRunEnd()
    {
        _ran = false;
    }
}