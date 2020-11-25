using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_EndLevel : MonoBehaviour
{
    [Header("Player Cheker")]
    [SerializeField] protected Transform _playerCheker;
    [SerializeField] protected Vector3 _checkArea;
    [SerializeField] protected LayerMask _playerLayer;
    Collider2D _playerEnter;

    protected void FixedUpdate()
    {
        _playerEnter = Physics2D.OverlapBox(_playerCheker.position, _checkArea, 0, _playerLayer);
        if (_playerEnter != null)
        {
            isDoorOpen();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_playerCheker.position, _checkArea);
    }

    private void isDoorOpen()
    {
        if (PlayerHasKey(_playerEnter))
        {
            PlayerPrefs.SetInt("Soul_Score", _playerEnter.GetComponent<InventorySystem>().GetSoul());
            ServiceManager.Instanse.EndLevel();
        }
    }

    private bool PlayerHasKey(Collider2D _player)
    {
        return _player.GetComponent<InventorySystem>().HasKey();
    }
}
