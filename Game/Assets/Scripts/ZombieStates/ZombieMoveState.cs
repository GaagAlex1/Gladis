using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveState : ZombieState
{
    public ZombieMoveState(Zombie _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        enemy.animator.Play("Move");
    }

    public override void LogicUpdate()
    {
        if (!enemy.handler.IsMove)
        {
            if (enemy.handler.IsAttack)
            {
                stateMachine.ChangeState(enemy.combat);
            }
            else
            {
                stateMachine.ChangeState(enemy.idle);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        velocity = new Vector3 (Mathf.Clamp(enemy.handler.Direction.x,-1,1), 0, Mathf.Clamp(enemy.handler.Direction.z, -1,1));
        if (enemy.handler.IsInLine) 
        {
            velocity = Quaternion.Euler(0, enemy.handler.deltaAngle, 0) * velocity / 1.75f;
        }
        enemy.characterController.Move(velocity * Time.deltaTime * enemy.speed);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(velocity),
                                    enemy.rotationDampTime);
    }
}
