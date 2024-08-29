using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : Jump
{
    [SerializeField] private float _longJumpDelay = 1f;
    [SerializeField] private float _longJumpMultiplier = 1.5f;

    public bool CanLongJump { get; private set; }
    public bool IsLongJumping { get; private set; }

   

    protected override void Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (!canJump)
            CanLongJump = false;

        if (collisionState.Standing && IsLongJumping)
            CanLongJump = false;

        base.Update();

        if(CanLongJump && !collisionState.Standing && holdTime > _longJumpDelay)
        {
            float sizeMult = size.GetSize / 2;
            var vel = body2D.velocity;
            body2D.velocity = new Vector2(vel.x, jumpSpeed * _longJumpMultiplier * sizeMult);
            CanLongJump = false;
            IsLongJumping = true;
        }
    }

    protected override void OnJump()
    {
        base.OnJump();
        CanLongJump = true;
    }
}
