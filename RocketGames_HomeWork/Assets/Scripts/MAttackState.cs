using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAttackState : StateBase
{
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public override void Enter()
    {
        _anim.SetBool("IsAttacking", true);
    }
    public override void Exit()
    {
        _anim.SetBool("IsAttacking", false);
    }
    public override void UpdateState()
    {
        
    }
}
