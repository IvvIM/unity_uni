using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Enemy_Controller : Enemy_Controller_Base
{
    [Header("State change time")]
    [SerializeField] protected float _maxStateTime;
    [SerializeField] protected float _minStateTime;

    private float _lastTimeChange;
    private float _timeToNextChange;
    private AttackShoot _enemyAttack;

    protected override void Start()
    {
        base.Start();
        _enemyAttack = GetComponent<AttackShoot>();
    }

    private void Update()
    {
        if (_currentState == EssenceState.Death)
            return;

        if (Time.time - _lastTimeChange > _timeToNextChange && !_seePlayer)
            GetRandomState();
        if (_seePlayer && _enemyHP._currentHP > 0 && _currentState != EssenceState.Hurt)
        {
            EndState();
            Shoot();
        }

        if (_enemyHP._currentHP < 0)
            ChangeState(EssenceState.Death);
    }

    #region Random State
    private void GetRandomState()
    {
        if (_currentState == EssenceState.Death)
            return;

        ResetEssenceAnim();
        int state = Random.Range(1, 3);

        if (_currentState == EssenceState.Idle && _availableState[state] == EssenceState.Idle)
            GetRandomState();

        ChangeState(_availableState[state]);
        _lastTimeChange = Time.time;
        _timeToNextChange = Random.Range(_minStateTime, _maxStateTime);
    }
    #endregion

    #region State shange
    protected override void EndState()
    {
        base.EndState();
        _enemyMovement.IsMoving(false);
    }

    protected void AfterHurt()
    {
        if (_currentState == EssenceState.Death)
            return;

        if (!_seePlayer)
        {
            _enemyMovement._enemyMove *= -1;
            ChangeState(EssenceState.Move);
        }
        else
            ChangeState(EssenceState.Shoot);
    }
    #endregion

    #region States
    protected override void None()
    {
        GetRandomState();
    }
    protected override void Move()
    {
        base.Move();
        _enemyMovement.IsMoving(true);
    }

    protected override void Shoot()
    {
        base.Shoot();
        _essenceAnim.SetBool("Shoot", true);
    }
    #endregion
}
