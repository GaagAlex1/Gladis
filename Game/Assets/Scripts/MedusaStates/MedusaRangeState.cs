using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaRangeState : MedusaState
{
    public MedusaRangeState(Medusa _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        medusa = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        medusa.animator.Play("RangeAttack");
    }
}
