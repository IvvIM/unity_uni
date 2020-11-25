using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ItemPickerBase
{
    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        _playerInv.TakeKey();
        PlayerExit();
        Destroy(gameObject);
    }
}
