using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRefs : MonoBehaviour
{
    private Transform player;
    private Textbox textbox;

    public Transform GetPlayer()
    {
        if (!player)
            player = FindObjectOfType<PlayerMovement>().transform;

        return player;
    }

    public Textbox GetTextbox()
    {
        if(!textbox)
        {
            textbox = FindObjectOfType<Textbox>();
        }

        return textbox;
    }
}
