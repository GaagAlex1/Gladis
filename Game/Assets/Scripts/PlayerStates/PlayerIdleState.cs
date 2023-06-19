using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Idle");
    }

    public override void LogicUpdate()
    {
        if (player.playerInput.IsMove)
        {
            if (player.playerInput.IsRoll)
            {
                player.stateMachine.ChangeState(player.rolling);
            } 
            else if (player.playerInput.IsJump) 
            {
                player.stateMachine.ChangeState(player.jump);
            }
            else if (player.playerInput.IsHeal)
            {
                player.stateMachine.ChangeState(player.heal);
            }
            else if (player.playerInput.IsBlock)
            {
                player.stateMachine.ChangeState(player.block);
            }
            else
            {
                player.stateMachine.ChangeState(player.move);
            }
        }
        else
        {
            if (player.playerInput.IsHit) 
            {
                player.stateMachine.ChangeState(player.combat);
            } 
            else if (player.playerInput.IsJump)
            {
                player.stateMachine.ChangeState(player.jump);
            }
            else if (player.playerInput.IsHeal)
            {
                player.stateMachine.ChangeState(player.heal);
            }
            else if (player.playerInput.IsBlock)
            {
                player.stateMachine.ChangeState(player.block);
            }
        }

        input = player.playerInput.MovementInput;
        velocity = new Vector3(input.x, 0, input.y);
        velocity.y = 0;
    }

    public override void PhysicsUpdate()
    {
    }

    public override void Exit()
    {
        
    }
}
