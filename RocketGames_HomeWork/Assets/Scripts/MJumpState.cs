using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJumpState : StateBase
{
    Rigidbody2D _rb;

    [SerializeField] float _power;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        
    }
    public override void Exit()
    {
        
    }
    public override void UpdateState()
    {
        _rb.AddForce(Vector2.up * _power);
    }
}
