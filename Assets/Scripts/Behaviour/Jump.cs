using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jump : AbstractBehaviour
{
    public float jumpSpeed = 10f;
    public float jumpDelay = .1f;
    public float jumpCount = 2f;

    private float time = 1f;

    protected float lastTimeJump = 0;
    protected float jumpsRemaining = 0;
    protected Size size;

    public static event Action OnJumped;

    public bool IsJump { get; private set; }

    private void Start()
    {
        size = GetComponent<Size>();
    }

    protected virtual void Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (collisionState.Standing)
        {
            IsJump = false;
            jumpsRemaining = jumpCount;
            if (canJump && holdTime < .1f)
            {
                OnJump();
                jumpsRemaining--;
            }
        }
        else
        {
            if (canJump && holdTime < .1f && Time.time - lastTimeJump > jumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                }
            }
        }

    }

    protected virtual void OnJump()
    {
        var vel = body2D.velocity;
        lastTimeJump = Time.time;
        body2D.velocity = new Vector2(vel.x, jumpSpeed);

        if (Time.time - time > .12f)
        {
            OnJumped?.Invoke();
            time = Time.time;
            IsJump = true;
        }
    }
}
