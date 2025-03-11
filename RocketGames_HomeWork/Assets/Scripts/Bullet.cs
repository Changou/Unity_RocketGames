using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int _atk;
    [SerializeField] float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;

        ExitScreen();
    }

    void ExitScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            PoolManager.ReturnBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            monster.OnDamage(_atk);
            PoolManager.ReturnBullet(this);
        }
        else
        {
            PoolManager.ReturnBullet(this);
        }
    }
}
