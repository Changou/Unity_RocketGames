using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("체력"), SerializeField] int _defalutHp;

    [SerializeField] MonsterState _mState;
    [Header("점프파워"), SerializeField] float _jPower;
    [Header("속도"), SerializeField] float _speed;
    [Header("공격력"), SerializeField] float _atk;
    [Header("백무빙"), SerializeField] float _backPower;
    [Header("감지된 오브젝트"), SerializeField] public GameObject _detectionObj;

    [SerializeField] SpriteRenderer _sprite;

    Rigidbody2D _rb;

    [SerializeField] float _maxVelX;
    [SerializeField] float _maxVelY;

    public float _JPower => _jPower;
    public float _Speed => _speed;
    public float _Atk => _atk;

    int _hp;

    private void OnEnable()
    {
        _hp = _defalutHp;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _mState.TransitionTo(MState.WALK);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = _rb.velocity;
        vel.x = Mathf.Clamp(vel.x, -_maxVelX, _maxVelX);
        vel.y = Mathf.Clamp(vel.y, -_maxVelY, _maxVelY);
        _rb.velocity = vel;
    }

    public void BackMove()
    {
        _rb.AddForce(Vector2.right * _backPower, ForceMode2D.Impulse);
    }

    public void OnDamage(int dmg)
    {
        _hp -= dmg;
        if(_hp <= 0)
        {
            Die();
        }
        else
            StartCoroutine("DamageEffect");
    }

    IEnumerator DamageEffect()
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _sprite.color = Color.white;
    }

    void Die()
    {
        _sprite.color = Color.white;
        PoolManager.ReturnMonster(this);
    }
}
