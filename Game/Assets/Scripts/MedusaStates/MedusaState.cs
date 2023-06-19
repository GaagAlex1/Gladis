using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaState : State
{
    public Medusa medusa;
    public StateMachine stateMachine;

    public Vector3 velocity;
    public MedusaState(Medusa _enemy, StateMachine _stateMachine)
    {
        medusa = _enemy;
        stateMachine = _stateMachine;
    }
}
