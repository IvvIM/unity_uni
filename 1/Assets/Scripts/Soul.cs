using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : ItemPickerBase
{
    [SerializeField] private int _sizeLoot;

    protected override void Start()
    {
        base.Start();
        _amountSoul = _sizeLoot;
    }
    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        _playerInv.AddSoul(_amountSoul);
        PlayerExit();
        Destroy(gameObject);
    }
}
