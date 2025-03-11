using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxPositionSet : MonoBehaviour
{
    [Header("히어로"), SerializeField] GameObject _hero;
    [Header("박스"), SerializeField] GameObject _box;
    [Header("First Pos"), SerializeField] Vector2 _fPos;
    [Header("OffsetY"), SerializeField] float _offsetY;

    [Header("박스 갯수"), SerializeField] int _boxCnt;

    List<GameObject> _boxes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _boxCnt; i++)
        {
            GameObject box = Instantiate(_box);
            box.transform.SetParent(transform);
            _boxes.Add(box);
        }
        GameObject hero = Instantiate(_hero);
        hero.transform.SetParent(transform);
        _boxes.Add(hero);
        BoxSetting();
    }

    public void RemoveBox(GameObject box)
    {
        _boxes.Remove(box);
        BoxSetting();
    }

    void BoxSetting()
    {
        for(int i = 0; i < _boxes.Count; i++)
        {
            Vector2 pos = _fPos;
            pos.y += i * _offsetY;
            _boxes[i].transform.localPosition = pos;
        }
    }
}
