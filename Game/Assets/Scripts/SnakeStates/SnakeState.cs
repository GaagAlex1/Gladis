using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeState : State
{
    public Snake snake;
    public StateMachine stateMachine;

    public Vector3 velocity;
    public SnakeState(Snake _enemy, StateMachine _stateMachine)
    {
        snake = _enemy;
        stateMachine = _stateMachine;
    }
}
