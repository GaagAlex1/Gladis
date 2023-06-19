using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class Player : Creature
{
    public PlayerMoveState move;
    public PlayerCombatState combat;
    public PlayerRollingState rolling;
    public PlayerJumpState jump;
    public PlayerHealingState heal;
    public PlayerBlockState block;
    public PlayerStunState stun;

    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;

    public float speed;
    public float jumpHeight;
    public float gravityValue;

    public CharacterController characterController;
    public PlayerInputHandler playerInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInputHandler>();

        stateMachine = new StateMachine();
        idle = new PlayerIdleState(this, stateMachine);
        move = new PlayerMoveState(this, stateMachine);
        combat = new PlayerCombatState(this, stateMachine);
        rolling = new PlayerRollingState(this, stateMachine);
        jump = new PlayerJumpState(this, stateMachine);
        heal = new PlayerHealingState(this, stateMachine);
        block = new PlayerBlockState(this, stateMachine);
        stun = new PlayerStunState(this, stateMachine);
        damage = new PlayerDamageState(this, stateMachine);

        stateMachine.Initialize(idle);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.PhysicsUpdate();
    }
}
