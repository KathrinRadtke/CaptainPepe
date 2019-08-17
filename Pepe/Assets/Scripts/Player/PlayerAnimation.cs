using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;

    private const string IsMovingBool = "isMoving";
    private const string facingInt = "facing";

    // Update is called once per frame
    void Update()
    {
        SetMoving();
        SetFacing();
    }

    private void SetMoving()
    {
        animator.SetBool(IsMovingBool, playerMovement.IsMoving());
    }

    private void SetFacing()
    {
        animator.SetInteger(facingInt, (int) playerMovement.currentFacing);
    }
}
