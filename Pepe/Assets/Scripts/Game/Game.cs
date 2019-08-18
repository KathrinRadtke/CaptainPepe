using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameRefs refs;
    public GameScenes scenes;
    public GameAudio gameAudio;

    public GameKeys keys;
    
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        gameAudio.PlayTheme();
    }
}
