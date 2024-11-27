using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int Health = 3;
    public GameObject deathEffect;
    private int health; 
    void Start()
    {
        health = Health; 
    }

    public void TakeDamage(int damage)
    {
       health -= damage; 
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); 
    }
}
