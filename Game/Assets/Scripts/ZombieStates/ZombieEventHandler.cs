using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEventHandler : BasicEnemyEventHandler
{
    [SerializeField] float moveDistance;
    [SerializeField] float attackDistance;
    public float deltaAngle;

    public bool IsMove { get => Distance <= moveDistance && Distance > attackDistance; }
    public bool IsAttack { get => Distance <= attackDistance; }
}
