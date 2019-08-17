using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRefs : MonoBehaviour
{
    private Transform player;

    public Transform GetPlayer()
    {
        if (!player)
            player = FindObjectOfType<PlayerMovement>().transform;

        return player;
    }
}
