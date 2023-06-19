using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamageState : ZombieState
{
    public ZombieDamageState(Zombie _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        enemy.animator.Play("Damage");
    }

    public override void LogicUpdate()
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            enemy.stateMachine.ChangeState(enemy.idle);
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
