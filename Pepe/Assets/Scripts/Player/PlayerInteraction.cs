using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool interactionEnabled = true;
    public PlayerMovement playerMovement;
    public float offsetMultiplicator = 0.5f;

    private Interaction currentInteraction;

    // Update is called once per frame
    void Update()
    {
        PositionArea();

        if(interactionEnabled)
            CheckInput();
    }

    private void PositionArea()
    {
        transform.position = playerMovement.transform.position + playerMovement.GetCurrentFacingVectorDirection() * offsetMultiplicator;
    }

    private void CheckInput()
    {
        if(Input.GetButtonDown(InputStrings.InteractButton))
        {
            if(currentInteraction && currentInteraction.isCurrentlyInteractable)
            {
                currentInteraction.OnInteraction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.InteractionTag))
        {
            currentInteraction = collision.GetComponent<Interaction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.InteractionTag) && currentInteraction.gameObject == collision.gameObject)
        {
            currentInteraction = null;
        }
    }
}
