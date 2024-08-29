using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = unlockedLevel; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void OpenScene(int level)
    {
        StartCoroutine(Timer());
        SceneManager.LoadScene("Level" + level.ToString());
    }

    IEnumerator Timer()
    {
        //Debug.Log("start: " + Time.time);
        yield return new WaitForSeconds(1);
        //Debug.Log("end: " + Time.time);
    }
}
