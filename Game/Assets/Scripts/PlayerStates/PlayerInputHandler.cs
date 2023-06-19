using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    private float _nextHit;
    private float _nextRoll;
    private float _nextJump;
    private float _Rate = 1.067f;
    public Vector2 MovementInput { get; private set; }
    public bool IsMove { get => MovementInput != Vector2.zero; }
    public bool IsHit { get; set; }
    public bool IsRoll { get; set; }
    public bool IsJump { get; set; }

    public bool IsHeal { get; set; }
    public bool IsBlock { get; set; }
    public bool OnCombo { get; set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (Time.time - _Rate <= _nextRoll) return;

        _nextRoll = Time.time;
        IsRoll = true;
    }

    public void OnHit(InputAction.CallbackContext context)
    {
        if (Time.time - _Rate <= _nextHit)
        {
            if (!OnCombo) OnCombo = context.started;
            return;
        }

        _nextHit = Time.time;
        IsHit = true;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (Time.time - _Rate <= _nextJump) return;

        _nextJump = Time.time;
        IsJump = true;
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (Time.time - _Rate <= _nextJump) return;

        _nextJump = Time.time;
        IsHeal = true;
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        IsBlock = !context.canceled;
    }
}
