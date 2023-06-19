using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : State
{
    public Player player;
    public StateMachine stateMachine;

    public PlayerInputHandler playerInput;

    protected Vector3 velocity;
    protected Vector2 input;
    protected Vector3 verticalVelocity;

    public PlayerState(Player _player, StateMachine _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }
}
