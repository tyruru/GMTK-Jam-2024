using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FaceDirection : AbstractBehaviour
{
    private void Update()
    {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if (right)
            inputState.directions = Directions.Right;
        else if (left)
            inputState.directions = Directions.Left;

        Vector3 vector3 = new Vector3((float)inputState.directions * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);

        transform.localScale = vector3;

        
    }
}
