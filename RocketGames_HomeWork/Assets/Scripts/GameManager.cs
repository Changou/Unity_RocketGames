using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _inst;

    public bool _isGameStart = false;

    public Action _GameStart;

    private void Awake()
    {
        _inst = this;
    }

    public void GameStart()
    {
        _isGameStart = true;
        _GameStart();
    }
}
