using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxLives = 3;
    public int currentLives = 3;

    public float respawnTime = 2f;

    public bool levelEnding;

    public bool isGameOver = false;

    public float waitForLevelEnd = 5f;

    private bool canPause;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentLives = PlayerPrefs.GetInt("CurrentLives", currentLives);
        Debug.Log("currentLives : " + currentLives);
        //UIManager.instance.livesText.text = "Health : " + currentLives;

        canPause = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            PauseUnpause();
        }

        if (WaveManager.instance.enemyAmount <= 0 && !isGameOver)
        {
            StartCoroutine(EndLevelCo());
        }
        else
        {
            //
        }
    }

    public void KillPlayer()
    {
        //if (currentLives <= 0)
        //{
        //    currentLives--;
        //    UIManager.instance.livesText.text = "x " + currentLives;
        //}
        //else
        //{
        //    currentLives = 0;
        //    UIManager.instance.livesText.text = "x " + currentLives;
        //}

        if (currentLives > 0)
        {
            //respawn code
            StartCoroutine(RespawnCo());
            currentLives--;
            //UIManager.instance.livesText.text = "Health : " + currentLives;
            UIManager.instance.UpdateHealthText(currentLives);
        }
        else
        {
            currentLives = 0;
            //UIManager.instance.livesText.text = "Health : " + currentLives;
            UIManager.instance.UpdateHealthText(currentLives);
            //game over code
            UIManager.instance.gameOverScreen.SetActive(true);
            PlayerMovement.instance.stopMovement = true;
            WaveManager.instance.canSpawnWaves = false;

            MusicController.instance.PlayGameOver();
            canPause = false;
        }
    }

    public IEnumerator RespawnCo()
    {

        yield return new WaitForSeconds(respawnTime);
        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }

    public IEnumerator EndLevelCo()
    {
        UIManager.instance.levelEndScreen.SetActive(true);
        PlayerMovement.instance.stopMovement = true;

        canPause = false;

        yield return new WaitForSeconds(1f);

        //PlayerPrefs.SetInt("CurrentLives", currentLives);
        //SceneManager.LoadScene(0); 

        UIManager.instance.continueButton.gameObject.SetActive(true);
        UIManager.instance.menuButton.gameObject.SetActive(true);
    }

    public void PauseUnpause()
    {
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            MusicController.instance.PlayLevelMusic();
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            PlayerMovement.instance.stopMovement = false;
        }
        else
        {
            MusicController.instance.PlayPauseMenu();
            UIManager.instance.pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            PlayerMovement.instance.stopMovement = true;
        }
    }
}