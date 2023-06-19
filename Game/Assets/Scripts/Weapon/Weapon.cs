using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public Collider collider;
    public WeaponManager manager;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            HitBox hb = collision.collider.GetComponent<HitBox>();
            hb.Hit(this);
            manager.DisableWeaponCollider();
        }
    }
}
