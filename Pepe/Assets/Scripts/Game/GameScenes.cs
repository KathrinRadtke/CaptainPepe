using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenes : MonoBehaviour
{
    public void SwitchToScene(string sceneName, Vector2 playerPosition, MusicTheme nextTheme = MusicTheme.NoChange)
    {
        StartCoroutine(SwitchSceneSequence(sceneName, playerPosition, nextTheme));

    }

    private IEnumerator SwitchSceneSequence(string sceneName, Vector2 playerPosition, MusicTheme nextTheme)
    {
        PlayerMovement playerMovement = Game.instance.refs.GetPlayerMovement();
        Facing lastFacing = playerMovement.currentFacing;
        playerMovement.canMove = false;
        playerMovement.StopMovement();
        AsyncOperation request = SceneManager.LoadSceneAsync(sceneName);
        request.allowSceneActivation = false;
        yield return StartCoroutine(Game.instance.refs.GetOverlay().FadeIn());
        request.allowSceneActivation = true;        
        yield return new WaitUntil(() => request.isDone);
        Game.instance.gameAudio.PlaySceneSwitchSound();
        Game.instance.gameAudio.PlayTheme(nextTheme);
        Game.instance.refs.GetPlayer().position = playerPosition;
        Game.instance.refs.GetPlayerMovement().currentFacing = lastFacing;
        yield return StartCoroutine(Game.instance.refs.GetOverlay().FadeOut());        
    }
}
