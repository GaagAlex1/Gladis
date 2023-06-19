using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        player.animator.Play("Run");
    }

    public override void LogicUpdate()
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
        else if (player.playerInput.IsBlock)
        {
            player.stateMachine.ChangeState(player.block);
        }
        else if (!player.playerInput.IsMove) 
        {
            player.stateMachine.ChangeState(player.idle);
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
}
