using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public WaveObject[] waves;

    public int enemyAmount = 0;

    public int currentWave;

    public float timeToNextWave;

    public bool canSpawnWaves;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeToNextWave = waves[0].timeToSpawn;

        for (int i = 0; i < waves.Length; i++)
        {
            foreach (var wave in waves[i].theWave.gameObject.transform)
            {
                int temp = 0;
                temp++;
                enemyAmount += temp;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnWaves)
        {
            timeToNextWave -= Time.deltaTime;
            if (timeToNextWave <= 0)
            {
                Instantiate(waves[currentWave].theWave, transform.position, transform.rotation);

                if (currentWave < waves.Length - 1)
                {
                    currentWave++;

                    timeToNextWave = waves[currentWave].timeToSpawn;
                }
                else
                {
                    canSpawnWaves = false;
                }
            }
        }
    }
    public void ContinueSpawning()
    {
        if (currentWave < waves.Length - 1 && timeToNextWave > 0)
        {
            canSpawnWaves = true;
        }
    }
}
[System.Serializable]
public class WaveObject
{
    public float timeToSpawn;
    public EnemyWave theWave;
}