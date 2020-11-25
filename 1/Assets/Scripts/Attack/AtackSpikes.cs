using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackSpikes : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _canAttack = true;
    public void OnTriggerEnter2D(Collider2D player)
    {
        TryToDamage(player);
    }
    private void TryToDamage(Collider2D player)
    {
        if (!_canAttack)
            return;

        player.GetComponent<Health_Controller>().TakeDamage(_damage);
        player.GetComponent<Rigidbody2D>().velocity = transform.up * _damage/2;
    }
}
