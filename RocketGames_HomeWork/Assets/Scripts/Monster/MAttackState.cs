using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAttackState : StateBase
{

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

    public void OnAttack()
    {
        if (_monster._detectionObj != null)
        {
            Box box = _monster._detectionObj.GetComponent<Box>();
            if (box != null)
            {
                box.OnDamage(_monster._Atk);
            }
        }
    }
}
