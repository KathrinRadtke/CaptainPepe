using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName;
    public Vector2 targetPlayerPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.PlayerTag))
        {
            Game.instance.scenes.SwitchToScene(targetSceneName, targetPlayerPosition);
        }
    }
}
