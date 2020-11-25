using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement_controller))]
public class PC_InputCrontroller : MonoBehaviour
{
    private Movement_controller _movement;
    private Health_Controller _hp;
    private Player_Controller _player;
    private InventorySystem _inv;
    float _move;
    bool _jump = false;
    bool _crouch = false;
    bool _shoot = false;
    bool _attack = false;
    bool _openCrate = false;
    int _attackType = 0;
    bool _playStop = false;
    void Start()
    {
        _hp = GetComponent<Health_Controller>();
        _player = GetComponent<Player_Controller>();
        _inv = GetComponent<InventorySystem>();
    }

    void Update()
    {
        if (_playStop)
            return; 
        _move = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            _jump = true;

        if (Input.GetKeyDown(KeyCode.C))
            _crouch = true;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            _shoot = true;
        if (Input.GetKeyDown(KeyCode.F))
        {
            _attack = true;
            _attackType = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
            _openCrate = true;
    }

    private void FixedUpdate()
    {
        _player.ForceChangeState("Move", _move);
        if (_jump)
        {
            _player.ForceChangeState("Jump");
            _jump = false;
        }
        if (_crouch)
            _player.ForceChangeState("Crouch");
        if (_attack)
        {
            _player.ForceChangeState("Strike");
            _attack = false;
        }
        if(_shoot)
        {
            _player.ForceChangeState("Shoot");
            _shoot = false;
        }
        if(_openCrate && _inv.GetCanOpenCrate())
        {
            _inv.OpenCrate();
            _openCrate = false;
        }    

    }

    public void StopPlay() 
    {
        _playStop = !_playStop;
    }

    public void SetCrouch(bool crouch)
    {
        _crouch = crouch;
    }
}

