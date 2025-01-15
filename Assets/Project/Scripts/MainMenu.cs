using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.GetString("LevelName", "Level1");
        Debug.Log("Level Name : " + PlayerPrefs.GetString("LevelName", "Level1"));
    }
    public void playGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(PlayerPrefs.GetString("LevelName", "Level1"));
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void creditsMenu()
    {
        SceneManager.LoadScene("Credits Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
