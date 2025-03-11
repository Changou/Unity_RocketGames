using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum Pooltype
{
    Monster,
    Bullet,

    Max
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager _inst;

    [SerializeField] GameObject _prefabMonster;
    [SerializeField] GameObject _prefabBullet;

    Queue<Monster> _poolingMonsterQueue = new Queue<Monster>();
    Queue<Bullet> _poolingBulletQueue = new Queue<Bullet>();

    [Header("풀링 몬스터 수"), SerializeField] int _poolMonsterCount;
    [Header("풀링 총알 수"), SerializeField] int _poolBulletCount;

    private void Awake()
    {
        _inst = this;

        Initialize(_poolMonsterCount, _poolBulletCount);
    }

    void Initialize(int initCountMonster, int initCountBullet)
    {
        for(int i = 0; i< initCountMonster; i++)
        {
            _poolingMonsterQueue.Enqueue(CreateNewMonster());
        }
        for(int i = 0; i< initCountBullet; i++)
        {
            _poolingBulletQueue.Enqueue(CreateNewBullet());
        }
    }

    Bullet CreateNewBullet()
    {
        var newObj = Instantiate(_prefabBullet).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    Monster CreateNewMonster()
    {
        var newObj = Instantiate(_prefabMonster).GetComponent<Monster>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Monster GetMonster()
    {
        if(_inst._poolingMonsterQueue.Count > 0)
        {
            var obj = _inst._poolingMonsterQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = _inst.CreateNewMonster();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }
    public static Bullet GetBullet()
    {
        if (_inst._poolingBulletQueue.Count > 0)
        {
            var obj = _inst._poolingBulletQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = _inst.CreateNewBullet();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnMonster(Monster obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(_inst.transform);
        _inst._poolingMonsterQueue.Enqueue(obj);
    }
    public static void ReturnBullet(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(_inst.transform);
        _inst._poolingBulletQueue.Enqueue(obj);
    }
}
