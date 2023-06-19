using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieState
{
    public ZombieIdleState(Zombie _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        enemy.animator.Play("Idle");
    }

    public override void LogicUpdate()
    {
        if (enemy.handler.IsAttack) 
        {
            stateMachine.ChangeState(enemy.combat);
        }
        else if (enemy.handler.IsMove)
        {
            stateMachine.ChangeState(enemy.move);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
