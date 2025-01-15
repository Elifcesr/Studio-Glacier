using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 startDirection;
    public Text enemyHealthText;
    public Slider enemyHealthSlider;

    public bool shouldChangeDirection;
    public float changeDirectionXPoint;

    public int maxHealth;
    public int currentHealth;
    public int damageAmount;

    public Vector2 changedDirection;

    void Start()
    {
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = currentHealth;

        UpdateEnemyHealthText(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            // transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
            if (!shouldChangeDirection)
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                if (transform.position.x > changeDirectionXPoint)
                {
                    transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
                else
                {
                    transform.position += new Vector3(changedDirection.x * moveSpeed * Time.deltaTime, changedDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
            }
        }
        else
        {
            moveSpeed = 0f;
        }
    }

    public void HurtEnemy()
    {
        currentHealth--;
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    public void UpdateEnemyHealthText(int currentHealth)
    {
        enemyHealthSlider.value = currentHealth;
        enemyHealthText.text = "Health : " + currentHealth;
    }
    private void OnBecameInvisible()
    {
        //Debug.Log(gameObject.name);
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FinishLine")
        {
            Debug.Log("can azalacak");
            WaveManager.instance.enemyAmount--;
            GameManager.instance.currentLives -= damageAmount;
            //UIManager.instance.livesText.text = "Health : " + GameManager.instance.currentLives;
            UIManager.instance.UpdateHealthText(GameManager.instance.currentLives);
            if (GameManager.instance.currentLives <= 0)
            {
                Debug.Log("gameover");
                GameManager.instance.isGameOver = true;
                //UIManager.instance.livesText.text = "Health : " + 0;
                UIManager.instance.UpdateHealthText(0);
                GameManager.instance.KillPlayer();
                WaveManager.instance.canSpawnWaves = false;
            }
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,.5f);
        }
    }
}