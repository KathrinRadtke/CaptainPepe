﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName;
    public Vector2 targetPlayerPosition;
    public MusicTheme nextSceneTheme = MusicTheme.NoChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.PlayerTag))
        {
            NPC npc = GetComponent<NPC>();
            if (npc)
                npc.OnInteraction();
            Game.instance.scenes.SwitchToScene(targetSceneName, targetPlayerPosition, nextSceneTheme);
        }
    }
}
