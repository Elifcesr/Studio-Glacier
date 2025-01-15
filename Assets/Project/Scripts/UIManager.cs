using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;

    public Text livesText;

    public Slider healthBar;

    public GameObject levelEndScreen;

    public GameObject pauseScreen;

    public Button continueButton;
    public Button menuButton;

    public string mainMenuName = "mainmenu";
    public string loadSceneName;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = GameManager.instance.maxLives;
        healthBar.value = GameManager.instance.currentLives;

        UpdateHealthText(GameManager.instance.currentLives);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHealthText(int currentHealth)
    {
        healthBar.value = currentHealth;
        livesText.text = "Health : " + currentHealth;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        GameManager.instance.PauseUnpause();
    }

    public void LevelSceneLoad()
    {
        if (PlayerPrefs.GetString("LevelName") == "Level3") 
        {
            PlayerPrefs.SetString("LevelName", "Level3");
        }
        else
        {
            PlayerPrefs.SetString("LevelName", loadSceneName);
        }
        SceneManager.LoadScene(loadSceneName);
    }
}