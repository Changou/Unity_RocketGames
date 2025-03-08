using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MState
{
    WALK,
    ATTACK,
    JUMP,
    DIE
}

public abstract class StateBase : MonoBehaviour
{
    public MState _mState;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
}

public class MonsterState : MonoBehaviour
{
    [SerializeField] MState _curState;
    [SerializeField] StateBase[] _stateBases;

    public MState _CurState => _curState;

    Dictionary<MState, StateBase> _stateDic;

    public void TransitionTo(MState nextState)
    {
        if(_curState == nextState) return;

        _stateDic[_curState].Exit();
        _curState = nextState;
        _stateDic[nextState].Enter();
    }

    void Awake()
    {
        _stateDic = new();
        foreach(StateBase stateBase in _stateBases)
        {
            _stateDic.TryAdd(stateBase._mState, stateBase);
        }
        _stateDic[_curState].Enter();
    }

    void Update()
    {
        _stateDic[_curState].UpdateState();    
    }
}
