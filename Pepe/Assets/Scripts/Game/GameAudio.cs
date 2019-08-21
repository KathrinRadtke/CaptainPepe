using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip mainTheme;
    public AudioClip barTheme;
    public AudioClip battleTheme;
    public AudioClip switchSceneSound;
    public AudioClip funfare;

    public void PlayTheme(MusicTheme theme)
    {
        switch(theme)
        {
            case MusicTheme.NoChange:
                break;

            case MusicTheme.Silence:
                PlayMusic(null);
                break;

            case MusicTheme.MainTheme:
                PlayMusic(mainTheme);
                break;

            case MusicTheme.BarTheme:
                PlayMusic(barTheme);
                break;

            case MusicTheme.BattleTheme:
                PlayMusic(battleTheme);
                break;
        }
    }

    public void PlaySceneSwitchSound()
    {
        PlaySoundOneShot(switchSceneSound);
    }

    public void PlayFunfare()
    {
        StartCoroutine(PlayFunfareSequence());
    }

    private IEnumerator PlayFunfareSequence()
    {
        audioSource.Stop();
        yield return null;
        PlaySoundOneShot(funfare);
        yield return new WaitForSeconds(funfare.length);
        audioSource.Play();
    }

    private void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    private void PlaySoundOneShot(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}

public enum MusicTheme
{
    NoChange,
    Silence,
    MainTheme,
    BarTheme,
    BattleTheme
}