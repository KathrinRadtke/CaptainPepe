using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayTheme()
    {
        audioSource.Play();
    }
}
