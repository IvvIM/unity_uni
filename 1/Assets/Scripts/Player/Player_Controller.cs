using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Controller_Base
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private int _maxAmmo;
    private ServiceManager _serviceManager;
    private Health_Controller _hp;
    private Movement_controller _movment;
    private InventorySystem _playerInv;
    private int _ammo = 0;

    protected override void Start()
    {
        base.Start();
        _hp = GetComponent<Health_Controller>();
        _movment = GetComponent<Movement_controller>();
        _playerInv = GetComponent<InventorySystem>();
        _serviceManager = ServiceManager.Instanse;
        _ammo = _maxAmmo;
    }

    #region States
    protected override void Move(float move)
    {
        base.Move();
        _movment.Move(move);
    }

    protected override void Jump()
    {
        base.Jump();
        _movment.Jump();
    }

    protected override void Crouch()
    {
        base.Crouch();
        _movment.Crouch();
    }

    protected override void Strike()
    {
        base.Strike();
        _weapon.GetComponent<Animator>().SetBool("Strike", true);
    }

    protected override void Shoot()
    {
        base.Shoot();
        _ammo -= 1;
        _weapon.GetComponent<Animator>().SetBool("Shoot", true);
        if (_ammo < 0)
        {
            _ammo = _maxAmmo;
            _weapon.GetComponent<Animator>().SetBool("Relode", true);
        }
    }

    protected override void Death()
    {
        Destroy(_weapon);
        base.Death();
        _serviceManager.Restart();
    }
    #endregion
}
