using System.Collections;
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
        AsyncOperation request = SceneManager.LoadSceneAsync(sceneName);
        request.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        request.allowSceneActivation = true;
    }
}
