using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public StateMachine stateMachine;

    public State idle;
    public State damage;
    public State dead;

    public Animator animator;
}
