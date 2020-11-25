using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float _bulletDamage;

    public void Init(float dmg)
    {
        _bulletDamage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.sharedMaterial != null)
            return;

        try
        {
            Health_Controller essence = hitInfo.GetComponent<Health_Controller>();
            if (!hitInfo.GetComponent<Controller_Base>().IsDeath())
                essence.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}
