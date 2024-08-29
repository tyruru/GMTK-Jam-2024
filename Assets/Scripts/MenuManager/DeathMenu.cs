using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;
    public Button pauseButton;

    private int activeScene;

    void Start()
    {
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoseGame()
    {
        pauseButton.gameObject.SetActive(false);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        int currentScene = activeScene;
        SceneManager.LoadScene("Level" + currentScene.ToString());
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
