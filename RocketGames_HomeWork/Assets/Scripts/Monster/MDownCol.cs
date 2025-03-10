using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDownCol : MonoBehaviour
{
    public bool _jump = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponent<Monster>();
        if(monster != null)
        {
            monster.BackMove();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null)
        {
            _jump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            _jump = false;
        }
    }
}
