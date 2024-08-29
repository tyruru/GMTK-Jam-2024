using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public DeathMenu deathMenu;
    public float minPoint = -8f;

    private void Update()
    {
        if (transform.position.y < minPoint)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<FaceDirection>().enabled = false;
        DeathMenu();
    }

    public void DeathMenu()
    {
        deathMenu.LoseGame();
    }
}
