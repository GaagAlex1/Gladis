using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    float vericalVel;

    public PlayerJumpState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("JumpStart");
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) player.animator.Play("Jump");
        vericalVel = Mathf.Sqrt(player.jumpHeight * -2f * player.gravityValue);
    }

    public override void LogicUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && player.transform.position.y <= 0)
        {
            player.playerInput.IsJump = false;
            player.animator.Play("JumpEnd");
        }

        if (!player.playerInput.IsJump) 
        {
            if (player.playerInput.IsMove)
            {
                if (player.playerInput.IsRoll)
                {
                    player.stateMachine.ChangeState(player.rolling);
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
        vericalVel += player.gravityValue * Time.deltaTime;
        verticalVelocity = new Vector3(0,vericalVel,0); 

        player.characterController.Move(velocity * Time.deltaTime * player.speed + verticalVelocity * Time.deltaTime);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(velocity),
                                    player.rotationDampTime);
    }
}
