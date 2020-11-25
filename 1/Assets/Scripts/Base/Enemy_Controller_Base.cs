using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Controller_Base : Controller_Base
{
    [Header("Player Cheker")]
    [SerializeField] protected Transform _playerCheker;
    [SerializeField] protected Vector3 _visibleArea;
    [SerializeField] protected LayerMask _playerLayer;

    [Header("Drop Loot")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;

    protected Health_Controller _enemyHP;
    protected Rigidbody2D _enemyRD;
    protected Enemy_Movement _enemyMovement;
    protected bool _seePlayer;

    protected virtual void Start()
    {
        base.Start();
        _enemyHP = GetComponent<Health_Controller>();
        _enemyRD = GetComponent<Rigidbody2D>();
        _enemyMovement = GetComponent<Enemy_Movement>();
    }

    protected virtual void FixedUpdate()
    {
        _seePlayer = Physics2D.OverlapBox(_playerCheker.position, _visibleArea, 0, _playerLayer);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_playerCheker.position, _visibleArea);
    }

    #region State change
    protected virtual void DisableEnemy()
    {
        _enemyRD.velocity = Vector2.zero;
        _enemyRD.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
    }
    #endregion

    #region Drop loot
    protected virtual void DropLoot()
    {
        GameObject loot = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);

    }
    #endregion
}
