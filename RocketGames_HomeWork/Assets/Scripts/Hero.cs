using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("������"), SerializeField] float _delay;
    [Header("��ź ��"), SerializeField] int _bulletCnt;
    [Header("�߻� ��ġ"), SerializeField] Transform _firePos;
    [Header("��ź ��"), SerializeField] float _angleZ;

    [SerializeField] bool _isShot = true;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _isShot && GameManager._inst._isGameStart)
        {
            Shot();
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        _isShot = false;
        yield return new WaitForSeconds(_delay);
        _isShot = true;
    }

    void Shot()
    {
        for(int i = 0; i < _bulletCnt;i++)
        {
            Bullet bullet = PoolManager.GetBullet();
            bullet.transform.SetParent(_firePos);
            bullet.transform.localPosition = Vector3.zero;
            
            Vector3 rotZ = new Vector3(0, 0, Random.Range(-_angleZ, _angleZ));
            bullet.transform.localRotation = Quaternion.Euler(rotZ);

            bullet.transform.SetParent(null);
        }
    }
}
