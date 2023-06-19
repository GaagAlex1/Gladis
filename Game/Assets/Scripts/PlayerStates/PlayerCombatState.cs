using UnityEngine;

public class PlayerCombatState : PlayerState
{
    public PlayerCombatState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Combat");
    }

    public override void LogicUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) {
            if (player.playerInput.OnCombo)
            {
                player.animator.Play("Combat 2");
            }
            else
            {
                player.playerInput.IsHit = false;
            }
            player.playerInput.OnCombo = false;
        } 

        if (!player.playerInput.IsHit)
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
                if (player.playerInput.IsHeal)
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
    }

    public override void PhysicsUpdate()
    {
    }

    public override void Exit()
    {
    }
}
