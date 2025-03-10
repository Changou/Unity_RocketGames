using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

    [SerializeField] float _speed;

    [SerializeField] WheelJoint2D _wheelFront;
    [SerializeField] WheelJoint2D _wheelBack;
    JointMotor2D _jMotor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Go();
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
