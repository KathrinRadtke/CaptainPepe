﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenes : MonoBehaviour
{
    public void SwitchToScene(string sceneName, Vector2 playerPosition)
    {
        StartCoroutine(SwitchSceneSequence(sceneName, playerPosition));

    }

    private IEnumerator SwitchSceneSequence(string sceneName, Vector2 playerPosition)
    {
        Game.instance.refs.GetPlayerMovement().canMove = false;
        Game.instance.refs.GetPlayerMovement().StopMovement();
        AsyncOperation request = SceneManager.LoadSceneAsync(sceneName);
        request.allowSceneActivation = false;
        yield return StartCoroutine(Game.instance.refs.GetOverlay().FadeIn());
        request.allowSceneActivation = true;
        yield return new WaitUntil(() => request.isDone);
        yield return StartCoroutine(Game.instance.refs.GetOverlay().FadeOut());
    }
}