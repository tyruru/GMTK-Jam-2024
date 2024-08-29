using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource hoverSound;


    public void ClickSound()
    {
        clickSound.Play();
    }

    public void HoverSound()
    {
        hoverSound.Play();
    }



    
}
