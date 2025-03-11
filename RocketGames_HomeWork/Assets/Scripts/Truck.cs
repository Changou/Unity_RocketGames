using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

    [SerializeField] float _speed;

    [SerializeField] WheelJoint2D _wheelFront;
    [SerializeField] WheelJoint2D _wheelBack;
    JointMotor2D _jMotor;

    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager._inst._GameStart += () => Go();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = _rb.velocity;
        if(vel.x < 0)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Go()
    {
        _wheelFront.useMotor = true;
        _wheelBack.useMotor = true;
        _jMotor.motorSpeed = _speed;
        _jMotor.maxMotorTorque = 1000f;

        _wheelFront.motor = _jMotor;
        _wheelBack.motor = _jMotor;
    }

}
