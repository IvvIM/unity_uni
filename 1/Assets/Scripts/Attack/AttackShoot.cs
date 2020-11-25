using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _canAttack = true;

    [Header("Bullet")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed;

    private void Shoot()
    {
        if (!_canAttack)
            return;

        GameObject bullet = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Init(_damage);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletSpeed;
        Destroy(bullet, 5f);
    }
}
