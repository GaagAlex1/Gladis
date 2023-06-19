using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunState : PlayerState
{
    float stunTime = 3f;

    public PlayerStunState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Stun");
    }

    public override void LogicUpdate()
    {
        stunTime -= Time.deltaTime;
        if (stunTime <= 0) 
        {
            player.stateMachine.ChangeState(player.idle);
        }
    }

    public override void PhysicsUpdate()
    {
    }

    public override void Exit()
    {

    }
}
