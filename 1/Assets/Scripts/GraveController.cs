using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveController : ItemPickerBase
{
    [Header("Loot")]
    [SerializeField] private int _minAmountLoot;
    [SerializeField] private int _maxAmountLoot;

    [Header("UI")]
    [SerializeField] private GameObject _eButton;

    protected override void Start()
    {
        base.Start();
        _amountSoul = Random.Range(_maxAmountLoot, _maxAmountLoot);
    }

    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        _playerInv.SetCanOpenCrate(true);
        _playerInv.Crate(this);
        _eButton.SetActive(true);
    }

    protected override void PlayerExit()
    {
        _playerInv.SetCanOpenCrate(false);
        _playerInv.Crate(null);
        _eButton.SetActive(false);
        base.PlayerExit();
    }

    public void TakeSoul()
    {
        _playerInv.AddSoul(_amountSoul);
        PlayerExit();
        Destroy(this);
    }
}
