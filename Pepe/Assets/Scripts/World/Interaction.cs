using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isCurrentlyInteractable = true;

    private void Awake()
    {
        gameObject.tag = Tags.InteractionTag;
    }

    public virtual void OnInteraction()
    {
        Debug.Log("interaction with " + gameObject.name);
    }
}
