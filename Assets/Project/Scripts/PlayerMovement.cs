using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minY = -4f;
    public float maxY = 4f;
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0, moveY, 0).normalized;

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}