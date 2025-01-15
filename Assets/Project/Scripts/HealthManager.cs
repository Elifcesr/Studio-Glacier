using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    [Header("Player Settings")]
    public int currentHealth;
    public int maxHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    public void HurtPlayer()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.KillPlayer();

            WaveManager.instance.canSpawnWaves = false;
        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
    }
}