using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource levelMusic, mainmenuMusic, pauseMenuMusic, WeaponMusic, victoryMusic, gameOverMusic;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        //PlayMainMenu();
        PlayLevelMusic();
    }

    void StopMusic()
    {
        levelMusic.Stop();
        mainmenuMusic.Stop();
        pauseMenuMusic.Stop();
        WeaponMusic.Stop();
        victoryMusic.Stop();
        gameOverMusic.Stop();
    }

    public void PlayLevelMusic()
    {
        StopMusic();
        levelMusic.Play();
    }

    public void PlayMainMenu()
    {
        StopMusic();
        mainmenuMusic.Play();
    }

    public void PlayPauseMenu()
    {
        StopMusic();
        pauseMenuMusic.Play();
    }

    public void PlayBulletMusic()
    {
        //StopMusic();
        WeaponMusic.Play();
    }

    public void PlayVictory()
    {
        StopMusic();
        victoryMusic.Play();
    }

    public void PlayGameOver()
    {
        StopMusic();
        gameOverMusic.Play();
    }
}
