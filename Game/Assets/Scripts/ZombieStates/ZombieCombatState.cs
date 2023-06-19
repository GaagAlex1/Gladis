using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieState
{
    public ZombieCombatState(Zombie _enemy, StateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
        enemy = _enemy;
        stateMachine = _enemyStateMachine;
    }

    public override void Enter()
    {
        enemy.animator.Play("Attack");
    }

    public override void LogicUpdate()
    {
        if (!enemy.handler.IsAttack)
        {
            if (enemy.handler.IsMove)
            {
                stateMachine.ChangeState(enemy.move);
            }
            else
            {
                stateMachine.ChangeState(enemy.idle);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(enemy.handler.Direction),
                                    enemy.rotationDampTime);
    }
}
