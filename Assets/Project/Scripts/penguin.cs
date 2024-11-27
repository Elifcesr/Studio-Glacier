using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class penguin : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    int health = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }
   
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 10f; 
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    public void Damage()
    {
        health--;
        if (health == 0)
            Destroy(gameObject);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * bulletSpeed; 
            }
        }
    }
}