using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJumpState : StateBase
{

    public override void Enter()
    {
        
    }
    public override void Exit()
    {
        
    }
    public override void UpdateState()
    {
        _rb.AddForce(Vector2.up * _monster._JPower);
    }
}
