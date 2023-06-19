using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : Creature
{
    public MedusaRangeState range;
    public MedusaDashState dash;

    public SnakeEventHandler handler;
    public CharacterController characterController;

    public float speed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        handler = GetComponent<SnakeEventHandler>();

        stateMachine = new StateMachine();
        range = new MedusaRangeState(this, stateMachine);
        dash = new MedusaDashState(this, stateMachine);

        stateMachine.Initialize(range);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.PhysicsUpdate();
    }
}
