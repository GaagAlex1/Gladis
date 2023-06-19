using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEventHandler : BasicEnemyEventHandler
{
    [SerializeField] float crawlDistance;
    [SerializeField] float biteDistance;
    public float deltaAngle;

    public bool IsCrawl { get => Distance > biteDistance && Distance <= crawlDistance; }
    public bool IsBite { get => Distance <= biteDistance; }
}
