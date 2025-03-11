using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [Header("체력"), SerializeField] float _hp = 100f;

    [Header("체력 UI"), SerializeField] GameObject _hpUI;

    [Header("폭발 이펙트"), SerializeField] GameObject _explotionEffect;

    [Header("스프라이트"), SerializeField] SpriteRenderer _sprite;

    float _defalutHp;

    Slider _hpSlider;

    bool _isCoroutineOn = false;

    void Awake()
    {
        _hpSlider = _hpUI.GetComponentInChildren<Slider>();
        _hpSlider.maxValue = _hp;
        _hpSlider.value = _hp;
        _hpUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _defalutHp = _hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp < _defalutHp) _hpUI.SetActive(true);
    }

    public void OnDamage(float dmg)
    {
        _hp -= dmg;
        if(_hp <= 0)
        {
            if (_isCoroutineOn)
                StopCoroutine("DamageEffect");
            Destroy();
        }
        else if (!_isCoroutineOn)
        {
            StartCoroutine("DamageEffect");
        }
        _hpSlider.value = _hp;
    }

    IEnumerator DamageEffect()
    {
        _isCoroutineOn = true;
        Color sprite = _sprite.color;
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _sprite.color = sprite;
        _isCoroutineOn = false;
    }

    private void Destroy()
    {
        BoxManager._inst.DestroyedBox(transform.gameObject);
        
        GameObject effect = Instantiate(_explotionEffect);
        effect.transform.position = transform.position;

        Destroy(gameObject);
    }
}
