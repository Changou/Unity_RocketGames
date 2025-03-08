using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDownCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();
        if(monster != null)
        {
            monster.BackMove();
        }
    }
}
