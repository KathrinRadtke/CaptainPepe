using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    public Rigidbody2D rb;
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxis(InputStrings.HorizontalAxis), Input.GetAxis(InputStrings.VerticalAxis)) * moveSpeed;
    }
}
