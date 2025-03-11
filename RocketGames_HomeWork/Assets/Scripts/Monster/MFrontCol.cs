using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MFrontCol : MonoBehaviour
{
    [SerializeField] MonsterState _monsterState;
    [SerializeField] MDownCol _dC;
    [SerializeField] Monster _ms;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _monsterState.TransitionTo(MState.ATTACK);
            _ms._detectionObj = collision.gameObject;
        }
        else if (collision.CompareTag("Zombie") && _dC._jump && collision.GetComponent<MonsterState>()._CurState != MState.JUMP)
        {
            _monsterState.TransitionTo(MState.JUMP);
        }
        else if (!_dC._jump)
        {
            _monsterState.TransitionTo(MState.WALK);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero") || collision.CompareTag("Zombie"))
        {
            _monsterState.TransitionTo(MState.WALK);
        }
    }
}
