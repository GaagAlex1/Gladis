using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : PlayerState
{

    public PlayerRollingState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Rolling");
    }

    public override void LogicUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) player.playerInput.IsRoll = false;

        if (!player.playerInput.IsRoll)
        {
            if (player.playerInput.IsMove)
            {
                if (player.playerInput.IsJump)
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
                else
                {
                    player.stateMachine.ChangeState(player.idle);
                }
            }
        }

        input = player.playerInput.MovementInput;
        velocity = new Vector3(input.x, 0, input.y);
        velocity.y = 0;
    }

    public override void PhysicsUpdate()
    {
        player.characterController.Move(velocity * Time.deltaTime * player.speed);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(velocity),
                                    player.rotationDampTime);
    }

    public override void Exit()
    {

    }

}
