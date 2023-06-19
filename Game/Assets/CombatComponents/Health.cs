using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Ragdoll ragdoll;

    private void Start()
    {
        currentHealth = maxHealth;     
        foreach (Rigidbody rb in ragdoll.rigidbodies)
        {
            HitBox hitBox = rb.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Creature creature = GetComponent<Creature>();
        creature.stateMachine.ChangeState(creature.damage);
        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Creature creature = GetComponent<Creature>();
        creature.stateMachine.ChangeState(creature.dead);
    }
}
