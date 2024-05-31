using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Animator animator;
    private int IsEstasMortHash;
    private int IsTalkHash;
    public InputController _input;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        IsEstasMortHash = Animator.StringToHash("EstasMort");
        IsTalkHash = Animator.StringToHash("Talk");
    }

    public void EstasMort()
    {
        bool IsEstasMort = animator.GetBool(IsEstasMortHash);

        animator.SetBool(IsEstasMortHash, true);
        Debug.Log("Funciona");
        Invoke("EstasMortFalse", 2.0f);
    }
    public void Talk()
    {
        bool IsTalk = animator.GetBool(IsTalkHash);

        animator.SetBool(IsTalkHash, true);
        Debug.Log("Funciona");
        Invoke("TalkFalse", 2.0f);
    }
    public void EstasMortFalse()
    {
        animator.SetBool(IsEstasMortHash, false);
    }
    public void TalkFalse()
    {
        animator.SetBool(IsTalkHash, false);
    }

    public void Flee()
    {
        transform.Translate(new Vector3(0, 3, 0));
    }

    public void Attack()
    {
        transform.Translate(new Vector3(-3, 0, 0));
    }
}
