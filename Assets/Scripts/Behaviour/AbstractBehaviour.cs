using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBehaviour : MonoBehaviour
{
    public Buttons[] inputButtons;

    protected InputState inputState;
    protected Rigidbody2D body2D;
    protected CollisionState collisionState;

    protected void Awake()
    {
        inputState = GetComponent<InputState>();
        body2D = GetComponent<Rigidbody2D>();
        collisionState = GetComponentInChildren<CollisionState>();
    }
}
