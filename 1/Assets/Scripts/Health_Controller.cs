using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Controller_Base))]
public class Health_Controller : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    public float _currentHP;

    [Header("UI")]
    [SerializeField] private Slider _hpSlider;

    private Controller_Base _essenceController;
    private Animator _essenceAnim;
    private bool _canBeDamaged;

    private void Start()
    {
        _hpSlider.maxValue = _maxHP;
        _essenceController = GetComponent<Controller_Base>();
        _essenceAnim = GetComponent<Animator>();
        _currentHP = _maxHP;
        _hpSlider.value = _currentHP;
    }

    #region Damage
    public void TakeDamage(float dmg)
    {
        if (_canBeDamaged)
            return;

        _currentHP -= dmg;
        _hpSlider.value = _currentHP;
        _essenceController.ForceChangeState("Hurt");

        if (_currentHP <= 0)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            _essenceController.ForceChangeState("Death");
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
    #endregion

    public void isBlockDamage(bool block)
    {
        _canBeDamaged = block;
    }

    public void RestoreHP(float hp)
    {
        _currentHP += hp;
        if (_currentHP > _maxHP)
            _currentHP = _maxHP;

        _hpSlider.value = _currentHP;
    }

    public float MaxHP()
    {
        return _maxHP;
    }
}
