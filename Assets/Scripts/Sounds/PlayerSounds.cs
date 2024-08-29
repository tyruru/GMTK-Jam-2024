using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource fall;
    public AudioSource walk;

    private void OnEnable()
    {
        Jump.OnJumped += JumpSound;
        CollisionState.OnLanded += FallSound;
        Walk.OnWalk += WalkSound;
    }

    private void OnDisable()
    {
        Jump.OnJumped -= JumpSound;
        CollisionState.OnLanded -= FallSound;
        Walk.OnWalk -= WalkSound;
    }

    public void JumpSound()
    {
        jump.Play();
    }

    public void FallSound()
    {
        fall.Play();
    }

    public void WalkSound()
    {
        walk.Play();
    }
}
