using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;

    public void DisableWeaponCollider()
    {
        weapon.collider.enabled = false;
    }

    public void EnableWeaponCollider()
    {
        weapon.collider.enabled = true;
    }
}
