using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _canAttack = true;

    [SerializeField] private float _powerPush;
    [SerializeField] private Transform _hitCheck;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Vector3 _hitArea;
    [SerializeField] private float _angle;
    private Animator _essenceAnimator;
    bool _hit;

    private void Start()
    {
        _essenceAnimator = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_hitCheck.position, _hitArea);
    }
    private void TryToDamage()
    {
        if (!_canAttack)
            return;

        Collider2D[] _hitEssences = Physics2D.OverlapBoxAll(_hitCheck.position, _hitArea, _angle, _enemyLayer);
        for (int i = 0; i < _hitEssences.Length; i++)
        {
            Health_Controller essence = _hitEssences[i].GetComponent<Health_Controller>();
            if (essence != null)
            {
                if (essence._currentHP > 0)
                {
                    essence.TakeDamage(_damage);
                    _hitEssences[i].GetComponent<Rigidbody2D>().velocity = transform.right * _powerPush;
                }
            }
        }
    }

    public void StartAttack()
    {
        if (!_canAttack)
            return;

        _essenceAnimator.SetBool("Strike", true);
    }

    public void Attack()
    {
        TryToDamage();
        _essenceAnimator.SetBool("Strike", false);
    }
}
