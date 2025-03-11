using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public static BoxManager _inst;

    [SerializeField] BoxPositionSet _boxPosSet;

    private void Awake()
    {
        _inst = this;
    }

    public void DestroyedBox(GameObject box)
    {
        _boxPosSet.RemoveBox(box);
    }
}
