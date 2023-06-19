using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaDashState : MedusaState
{
    public MedusaDashState(Medusa _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        medusa = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        medusa.animator.Play("Dash");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
