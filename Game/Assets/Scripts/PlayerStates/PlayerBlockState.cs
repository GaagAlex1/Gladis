using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerState
{
    public PlayerBlockState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Block");
    }

    public override void LogicUpdate()
    {
        if (!player.playerInput.IsBlock)
        {
            if (player.playerInput.IsJump)
            {
                player.stateMachine.ChangeState(player.jump);
            }
            else if (player.playerInput.IsRoll)
            {
                player.stateMachine.ChangeState(player.rolling);
            }
            else if (player.playerInput.IsHit)
            {
                player.stateMachine.ChangeState(player.combat);
            }
            else if (player.playerInput.IsHeal)
            {
                player.stateMachine.ChangeState(player.heal);
            }
            else if (!player.playerInput.IsMove)
            {
                player.stateMachine.ChangeState(player.idle);
            }
            else
            {
                player.stateMachine.ChangeState(player.move);
            }
        }
        
        input = player.playerInput.MovementInput;
        velocity = new Vector3(input.x, 0, input.y);
        velocity.y = 0;
    }

    public override void PhysicsUpdate()
    {
    }
}
