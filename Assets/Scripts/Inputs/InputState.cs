using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    public bool value;
    public float holdTime = 0;
}


public enum Directions
{
    Right = 1,
    Left = -1
}

public class InputState : MonoBehaviour
{
    public Directions directions = Directions.Right;

    private Rigidbody2D _rigidbody2D;
    private Dictionary<Buttons, ButtonState> _buttonStates = new();

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetButtonValue(Buttons key, bool value)
    {
        if (!_buttonStates.ContainsKey(key))
            _buttonStates.Add(key, new ButtonState());

        var state = _buttonStates[key];

        if(state.value && !value)
        {
            state.holdTime = 0;
            //Debug.Log("InputState if" + key);

        }
        else if(state.value && value)
        {
            state.holdTime += Time.deltaTime;
            //Debug.Log("InputState else if" + key);

        }

        state.value = value;
    }

    public bool GetButtonValue(Buttons key)
    {
        if (_buttonStates.ContainsKey(key))
        {
            //Debug.Log(key + " - " + _buttonStates[key].value);
            return _buttonStates[key].value;
        }

        return false;
    }

    public float GetButtonHoldTime(Buttons key)
    {
        if (_buttonStates.ContainsKey(key))
            return _buttonStates[key].holdTime;
        else
            return 0f;
    }
}