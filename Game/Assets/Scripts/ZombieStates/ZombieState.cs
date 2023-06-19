using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : State
{
    public Zombie enemy;
    public StateMachine stateMachine;
    public Vector3 velocity;

    public ZombieState(Zombie _enemy, StateMachine _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }
}
