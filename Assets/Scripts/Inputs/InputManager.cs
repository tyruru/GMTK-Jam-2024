using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons
{
    Left,
    Right,
    Jump,
    TakeSize,
    GiveSize
}

public enum Condition
{
    GreaterThan,
    LessThan
}

[System.Serializable]
public class InputAxicState
{
    public string axicName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool Value
    {
        get
        {
            var val = Input.GetAxis(axicName);
            switch (condition)
            {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }
            return false;

        }
    }
}


public class InputManager : MonoBehaviour
{
    public InputAxicState[] inputs;
    public InputState inputState;

    private void Update()
    {
        foreach(var input in inputs)
        {
            Debug.Log(input.button + " - " + input.Value);
            inputState.SetButtonValue(input.button, input.Value);
        }
    }
}
