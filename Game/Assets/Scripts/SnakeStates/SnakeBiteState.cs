using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBiteState : SnakeState
{
    public SnakeBiteState(Snake _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        snake = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        snake.animator.Play("Bite");
    }

    public override void LogicUpdate()
    {
        if (!snake.handler.IsBite)
        {
            if (snake.handler.IsCrawl)
            {
                stateMachine.ChangeState(snake.crawl);
            } else
            {
                stateMachine.ChangeState(snake.idle);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        snake.transform.rotation = Quaternion.Slerp(snake.transform.rotation, Quaternion.LookRotation(-snake.handler.Direction),0.15f);
    }
}
