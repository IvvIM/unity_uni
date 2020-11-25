using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPickerBase : MonoBehaviour
{
    protected int _amountSoul;
    [SerializeField] protected LayerMask _playerLayer;
    protected Transform _item;
    protected Collider2D _playerColl;
    protected InventorySystem _playerInv;
    bool _wasEnter = false;

    protected virtual void Start()
    {
        _item = GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        _playerColl = Physics2D.OverlapBox(_item.position, _item.GetComponent<SpriteRenderer>().size, 0, _playerLayer);
        if (_playerColl != null)
            PlayerEnter();
        else if (_wasEnter)
            PlayerExit();
    }

    protected virtual void PlayerEnter()
    {
        _playerInv = _playerColl.GetComponent<InventorySystem>();
        _wasEnter = true;
    }

    protected virtual void PlayerExit()
    {
        _playerInv = null;
        _wasEnter = false;
    }
}
