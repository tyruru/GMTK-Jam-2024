using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Walk : AbstractBehaviour
{
    [SerializeField]
    private float _speed = 0f;


    public bool IsWalk { get; private set; }

    public static event Action OnWalk;

    private void Update()
    {
        var left = inputState.GetButtonValue(inputButtons[0]);
        var right = inputState.GetButtonValue(inputButtons[1]);

        //Debug.Log(right);

        if (right || left)
        {
            var velx = _speed * (float)inputState.directions;
            body2D.velocity = new Vector2(velx, body2D.velocity.y);
            IsWalk = true;
            //Debug.Log("walk");
        }
        else
        {
            //body2D.velocity = new Vector2(0, 0); 
            IsWalk = false;
        }

    }

    public void WalkSound()
    {
        OnWalk?.Invoke();
    }
}
