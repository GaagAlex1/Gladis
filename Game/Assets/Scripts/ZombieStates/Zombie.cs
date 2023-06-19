using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Creature
{
    public ZombieMoveState move;
    public ZombieCombatState combat;

    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;

    public float speed;
    public float jumpHeight;

    public CharacterController characterController;
    public ZombieEventHandler handler;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        handler = GetComponent<ZombieEventHandler>();

        stateMachine = new StateMachine();

        idle = new ZombieIdleState(this, stateMachine);
        move = new ZombieMoveState(this, stateMachine);
        combat = new ZombieCombatState(this, stateMachine);
        damage = new ZombieDamageState(this, stateMachine);
        dead = new ZombieDeadState(this, stateMachine);

        stateMachine.Initialize(idle);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.PhysicsUpdate();
    }

    private void FixedUpdate()
    {
    }
}
