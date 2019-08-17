using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    public Rigidbody2D rb;
    public float moveSpeed = 1f;
    public Facing currentFacing;

    private Vector2 currentInput = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        currentInput = new Vector2(Input.GetAxis(InputStrings.HorizontalAxis), Input.GetAxis(InputStrings.VerticalAxis));
        DetermineFacing(currentInput);

        if (canMove)
            Move();
    }

    private void Move()
    {
        rb.velocity = currentInput * moveSpeed;
    }

    private void DetermineFacing(Vector2 currentDirection)
    {
        if(currentDirection.x > 0f)
            currentFacing = Facing.Right;
        else if (currentDirection.x < 0f)
            currentFacing = Facing.Left;
        else if (currentDirection.y > 0f)
            currentFacing = Facing.Up;
        else if (currentDirection.y < 0f)
            currentFacing = Facing.Down;
    }

    public Vector3 GetCurrentFacingVectorDirection()
    {
        Vector3 facingVectorDirection = Vector3.zero;

        switch(currentFacing)
        {
            case Facing.Right:
                facingVectorDirection = new Vector3(1f, 0f, 0f);
                break;

            case Facing.Left:
                facingVectorDirection = new Vector3(-1f, 0f, 0f);
                break;

            case Facing.Up:
                facingVectorDirection = new Vector3(0f, 1f, 0f);
                break;

            case Facing.Down:
                facingVectorDirection = new Vector3(0f, -1f, 0f);
                break;
        }

        return facingVectorDirection;
    }
}

public enum Facing
{
    None,
    Right,
    Left,
    Up,
    Down
}