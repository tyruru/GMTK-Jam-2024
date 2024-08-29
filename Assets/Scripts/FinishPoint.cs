using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public WinMenu winMenu;
    public GameObject endMenu;

    //private int nextSceneLoad;

    //private void Start()
    //{
    //    nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    //}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Time.timeScale = 0f;
                endMenu.SetActive(true);
            }
            else
            {
                UnlockNewLevel();
                winMenu.WinGame();
            }
        }
    }

    private void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
