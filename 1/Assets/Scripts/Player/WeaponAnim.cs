using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnim : MonoBehaviour
{
    private Animator _weaponAnim;

    private void Start()
    {
        _weaponAnim = GetComponent<Animator>();
    }
    
    private void EndStrike()
    {
        _weaponAnim.SetBool("Strike", false);
    }

    private void EndShoot()
    {
        _weaponAnim.SetBool("Shoot", false);
    }

    private void EndRelode()
    {
        _weaponAnim.SetBool("Relode", false);
    }
}
