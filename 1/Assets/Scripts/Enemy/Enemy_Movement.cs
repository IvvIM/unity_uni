using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : Movement_Base
{
    [SerializeField] private Canvas _canvas;
    private  bool _enemyIsMoving = false;
    public float _enemyMove = 1f;
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_enemyIsMoving && !_isLayer)
            _enemyMove *= -1;

        if (_enemyIsMoving)
            Move(_enemyMove);
    }

    protected override void Flip()
    {
        base.Flip();
        _canvas.transform.Rotate(0, 180, 0);
    }

    public void IsMoving(bool status)
    {
        _enemyIsMoving = status;
    }
}
