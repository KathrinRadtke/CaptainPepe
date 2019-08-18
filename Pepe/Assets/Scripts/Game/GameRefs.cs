using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRefs : MonoBehaviour
{
    private Transform player;
    private PlayerMovement playerMovement;
    private Textbox textbox;
    private Overlay overlay;

    public Transform GetPlayer()
    {
        if (!player)
            player = FindObjectOfType<PlayerMovement>().transform;

        return player;
    }

    public Overlay GetOverlay()
    {
        if (!overlay)
            overlay = FindObjectOfType<Overlay>();

        return overlay;
    }

    public PlayerMovement GetPlayerMovement()
    {
        if (!playerMovement)
            playerMovement = FindObjectOfType<PlayerMovement>();

        return playerMovement;
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
