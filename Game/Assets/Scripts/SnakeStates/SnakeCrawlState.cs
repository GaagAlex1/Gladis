using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCrawlState : SnakeState
{
    public SnakeCrawlState(Snake _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        snake = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        snake.animator.Play("Crawl");
    }

    public override void LogicUpdate()
    {
        if (!snake.handler.IsCrawl)
        {
            if (snake.handler.IsBite)
            {
                stateMachine.ChangeState(snake.bite);
            }
            else
            {
                stateMachine.ChangeState(snake.idle);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        velocity = new Vector3(Mathf.Clamp(snake.handler.Direction.x, -1, 1), 0, Mathf.Clamp(snake.handler.Direction.z, -1, 1));
        snake.characterController.Move(velocity * Time.deltaTime * snake.speed);
        snake.transform.rotation = Quaternion.Slerp(snake.transform.rotation, Quaternion.LookRotation(-velocity),
                                    0.15f);
    }
}
