using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class Movement_Base : MonoBehaviour
{
    [Header("Horizontal movement")]
    [SerializeField] protected float _speed;
    protected bool _canMove = true;
    protected bool _faceRight = true;

    [Header("Layer Cheker")]
    [SerializeField] protected Transform _layerCheck;
    [SerializeField] protected float _radius;
    [SerializeField] protected LayerMask _layer;

    protected Animator _essenceAnim;
    protected Rigidbody2D _essenceRD;
    protected bool _isLayer;
    private LayerMask _useLayer;

    protected virtual void Start()
    {
        _useLayer = _layer;
        _essenceAnim = GetComponent<Animator>();
        _essenceRD = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        _isLayer = Physics2D.OverlapCircle(_layerCheck.position, _radius, _useLayer);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_layerCheck.position, _radius);
    }

    #region Movement
    public virtual void Move(float move)
    {
        if (!_canMove) return;

        _essenceAnim.SetFloat("Move", Mathf.Abs(move));

        _essenceRD.velocity = new Vector2(_speed * move, _essenceRD.velocity.y);

        if (move > 0 && !_faceRight)
            Flip();
        else if (move < 0 && _faceRight)
            Flip();
    }

    protected virtual void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }
    #endregion

    #region Public Functions
    public void SetUseLayer(LayerMask layer)
    {
        _useLayer = layer;
    }
    public void CanMove(bool canMove)
    {
        _canMove = canMove;
    }
    public bool GetIsLayer()
    {
        return _isLayer;
    }
    #endregion
}
