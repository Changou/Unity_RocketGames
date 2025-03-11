using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public void DestroyedExplotion()
    {
        Destroy(transform.parent.gameObject);
    }
}
