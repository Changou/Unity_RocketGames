using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWalkState : StateBase
{

    public override void Enter()
    {

    }
    public override void Exit()
    {
        //Debug.Log("Exit Walk");
    }
    public override void UpdateState()
    {
        _rb.AddForce(Vector2.left * _monster._Speed, ForceMode2D.Force);
    }
}
