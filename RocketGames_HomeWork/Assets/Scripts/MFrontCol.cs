using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MFrontCol : MonoBehaviour
{
    [SerializeField] MonsterState _monsterState;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _monsterState.TransitionTo(MState.ATTACK);
        }
        else if (collision.CompareTag("Zombie"))
        {
            _monsterState.TransitionTo(MState.JUMP);
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
