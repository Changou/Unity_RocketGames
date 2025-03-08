using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] MonsterState _mState;
    [SerializeField] float _speed;
    [SerializeField] float _backPower;
    Rigidbody2D _rb;

    [SerializeField] bool _isUp = false;

    [SerializeField] float _maxVelX;
    [SerializeField] float _maxVelY;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _mState.TransitionTo(MState.WALK);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mState._CurState == MState.ATTACK && !_isUp) return;

        Walk();

        Vector2 vel = _rb.velocity;
        vel.x = Mathf.Clamp(vel.x, -_maxVelX, _maxVelX);
        vel.y = Mathf.Clamp(vel.y, -_maxVelY, _maxVelY);
        _rb.velocity = vel;
    }

    void Walk()
    {
        _rb.AddForce(Vector2.left * _speed, ForceMode2D.Force);
    }

    public void BackMove()
    {
        _rb.AddForce(Vector2.right * _backPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Load"))
        {
            _isUp = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Load"))
        {
            _isUp = true;
        }
    }

    public void OnAttack()
    {

    }
}
