using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator _animator;
    private Walk _walk;
    private LongJump _jump;
    private CollisionState _collisionState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _walk = GetComponent<Walk>();
        _jump = GetComponent<LongJump>();
        _collisionState = GetComponentInChildren<CollisionState>();

    }

    private void Update()
    {
        if(_collisionState.Standing)
            ChangeAnimationState(0);

        if (_walk.IsWalk)
            ChangeAnimationState(1);

        if (!_collisionState.Standing)
            ChangeAnimationState(2);

        if (!_collisionState.Standing && !_jump.IsJump)
            ChangeAnimationState(3);
        
           
    }

    private void ChangeAnimationState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
