using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Singleton instance
    public static PlayerMovement instance;

    public float moveSpeed = 5f;
    public float minY = -4f;
    public float maxY = 4f;

    public bool stopMovement = false;

    void Awake()
    {
        // Singleton control
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        if (!stopMovement)
        {
            Move();
        }
    }

    void Move()
    {
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0, moveY, 0).normalized;

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
    public void SetMovement(bool canMove)
    {
        stopMovement = !canMove;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.CompareTag("FinishLine"))
        //{
        //    HealthManager.instance.HurtPlayer();
        //}
    }
}
