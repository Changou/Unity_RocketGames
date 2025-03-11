using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    [Header("카메라"), SerializeField] CinemachineVirtualCamera _cam;

    [Header("OffSet"), SerializeField] Vector2 _offset;

    [Header("스폰")]
    [SerializeField] float _delay;


    // Start is called before the first frame update
    void Start()
    {
        GameManager._inst._GameStart += () => StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = _cam.transform.position;
        transform.position = new Vector3(pos.x + _offset.x, pos.y + _offset.y, 0);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Monster monster = PoolManager.GetMonster();
            monster.transform.position = transform.position;

            int ran = Random.Range(1, 4);
            string mon = "Monster" + ran.ToString();

            int layer = LayerMask.NameToLayer(mon);

            ChangeLayerRecursively(monster.gameObject, layer);

            monster.GetComponent<SortingGroup>().sortingOrder = ran;

            yield return null;
        }
    }

    void ChangeLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach(Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject, layer);
        }
    }
}
