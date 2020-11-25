using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller_Base : MonoBehaviour
{
    [Header("State Changes")]
    [SerializeField] protected bool _useAttackTogether = false;
    [SerializeField] protected EssenceState[] _availableState;
    protected EssenceState _currentState;

    protected Animator _essenceAnim;

    protected virtual void Start()
    {
        _essenceAnim = GetComponent<Animator>();
    }

    public enum EssenceState
    {
        None,
        Idle,
        Move,
        Crouch,
        Jump,
        Strike,
        PowerStrike,
        Shoot,
        Hurt,
        Death
    }

    #region State Change
    protected virtual void ChangeState(EssenceState state)
    {
        IsDeath();
        EndState();

        switch (state)
        {
            case EssenceState.Idle:
                Idle();
                break;

            case EssenceState.Move:
                Move();
                break;

            case EssenceState.Jump:
                Jump();
                break;

            case EssenceState.Crouch:
                Crouch();
                break;

            case EssenceState.Strike:
                Strike();
                break;

            case EssenceState.PowerStrike:
                PowerStrike();
                break;

            case EssenceState.Shoot:
                Shoot();
                break;

            case EssenceState.Hurt:
                Hurt();
                break;

            case EssenceState.Death:
                Death();
                break;
        }
    }

    protected virtual void ChangeState(EssenceState state, float move)
    {
        IsDeath();
        if (_currentState == EssenceState.Hurt)
            return;
        EndState();

        Move(move);
    }

    public virtual void ForceChangeState(String state)
    {
        EssenceState changeOnState;
        Enum.TryParse(state,out changeOnState);
        ChangeState(changeOnState);
    }

    public virtual void ForceChangeState(String state, float move)
    {
        EssenceState changeOnState;
        Enum.TryParse(state, out changeOnState);
        ChangeState(changeOnState, move);
    }


    protected virtual void ResetEssenceAnim()
    {
        IsDeath();

        for (int i = 2; i < _availableState.Length; i++)
        {
            if (_availableState[i] != EssenceState.Move)
                _essenceAnim.SetBool(_availableState[i].ToString(), false);
            else
                _essenceAnim.SetFloat(EssenceState.Move.ToString(), 0);
        }
    }

    protected virtual void EndState()
    {
        _currentState = EssenceState.None;

        ResetEssenceAnim();
    }
    #endregion

    #region States
    protected virtual void None()
    {
        _currentState = EssenceState.Idle;
    }

    protected virtual void Idle()
    {
        _currentState = EssenceState.Idle;
    }

    protected virtual void Move()
    {
        _currentState = EssenceState.Move;
    }

    protected virtual void Move(float move)
    {
        _currentState = EssenceState.Move;
    }

    protected virtual void Crouch()
    {
        _currentState = EssenceState.Crouch;
    }

    protected virtual void Jump()
    {
        _currentState = EssenceState.Jump;
    }

    protected virtual void Strike()
    {
        if (!_useAttackTogether)
            _currentState = EssenceState.Strike;
    }

    protected virtual void PowerStrike()
    {
        if (!_useAttackTogether)
            _currentState = EssenceState.PowerStrike;
    }

    protected virtual void Shoot()
    {
        if (!_useAttackTogether)
            _currentState = EssenceState.Shoot;
    }

    protected virtual void Hurt()
    {
        _currentState = EssenceState.Hurt;
        _essenceAnim.SetBool("Hurt", true);
    }

    protected virtual void Death()
    {
        _currentState = EssenceState.Death;
        ResetEssenceAnim();
        _essenceAnim.SetBool("Death", true);
    }

    public bool IsDeath()
    {
        if (_currentState == EssenceState.Death)
            return true;

        return false;
    }
    #endregion

    #region PublicMethods
    public string GetCorrectState()
    {
        return _currentState.ToString();
    }
    #endregion
}

