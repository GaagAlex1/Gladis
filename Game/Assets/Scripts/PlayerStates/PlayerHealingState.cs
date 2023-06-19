using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealingState : PlayerState
{
    public PlayerHealingState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Heal");
    }

    public override void LogicUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            player.playerInput.IsHeal = false;
        }

        if (!player.playerInput.IsHeal)
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
        /*player.GetComponent<Stats>()._currentHP += 1;*/

        player.characterController.Move(velocity * Time.deltaTime * player.speed / 3);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(velocity),
                                    player.rotationDampTime);
    }
}
