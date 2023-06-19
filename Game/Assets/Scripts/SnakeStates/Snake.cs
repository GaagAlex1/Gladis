using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : Creature
{
    public SnakeCrawlState crawl;
    public SnakeBiteState bite;

    public SnakeEventHandler handler;
    public CharacterController characterController;

    public float speed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        handler = GetComponent<SnakeEventHandler>();

        stateMachine = new StateMachine();
        crawl = new SnakeCrawlState(this, stateMachine);
        bite = new SnakeBiteState(this, stateMachine);

        stateMachine.Initialize(crawl);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
        stateMachine.currentState.PhysicsUpdate();
    }
}
