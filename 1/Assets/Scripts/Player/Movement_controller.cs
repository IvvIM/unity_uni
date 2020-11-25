using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_controller : Movement_Base
{

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    private bool _canDoubleJump = true;

    [Header("Crouch")]
    [SerializeField] private Transform _standUpCheck;
    [SerializeField] private Collider2D _bodyColider;
    private bool _canStandUp;
    bool _isCrouch = false;

    private PC_InputCrontroller _crouchBool;

    protected override void Start()
    {
        base.Start();
        _crouchBool = GetComponent<PC_InputCrontroller>();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_standUpCheck.position, _radius);
    }

    #region Jump
    public void Jump()
    {
        if (_isLayer || _canDoubleJump)
        {
            _essenceRD.velocity = new Vector2(_essenceRD.velocity.x, _jumpForce);
            _canDoubleJump = !_canDoubleJump;
        }
    }
    #endregion

    #region Crouch
    public void Crouch()
    {
        if (!_isCrouch)
        {
            _bodyColider.enabled = false;
            _isCrouch = true;
            _crouchBool.SetCrouch(false);
            return;
        }

        _canStandUp = !Physics2D.OverlapCircle(_standUpCheck.position, _radius, _layer);

        if (_canStandUp)
        {
            _bodyColider.enabled = true;
            _isCrouch = false;
            _crouchBool.SetCrouch(false);
            return;
        }

        _crouchBool.SetCrouch(true);
        return; 
    }

    public bool GetIsCrouch()
    {
        return _isCrouch;
    }
    #endregion
}
