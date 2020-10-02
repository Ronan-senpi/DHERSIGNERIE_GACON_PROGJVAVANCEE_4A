using Assets.Scripts.others;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;

    private float maxVolumeMusic = 1f;
    private float maxVolumeFx = 1f;
    private void SetVolumeMax(float music = 1f, float fx = 1f)
    {
        maxVolumeMusic = music;
        maxVolumeFx = fx;
    }

    public static AudioManager instance { get; set; }

    // Awake est appelé quand l'instance de script est chargée
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }

        foreach (var s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.GetClip();
            s.Source.volume = s.GetVolume();
            s.Source.pitch = s.Getpitch();
        }
    }

    private Sound Find(string name)
    {
       return Array.Find(sounds, sound => sound.GetName() == name);
    }

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    public Sound Play(string name)
    {
        Sound s = Find(name);
        if (s != null)
        {
            s.Source.Play();
            return s;
        }
        return null;
    }

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    /// <param name="FadeInTime">Time of fade in (seconds)</param>
    /// <returns>Played sound</returns>
    public Sound Play(string name, float FadeInTime)
    {
        Sound s = this.Play(name);
        if (s != null)
        {
            s.Source.volume = .2f;
            StartCoroutine(FadeIn(s.Source, FadeInTime));
        }
        return s;
    }
    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    public Sound Stop(string name)
    {
        Sound s = Find(name);
        if (s != null)
        {
            s.Source.Stop();
            return s;
        }
        return null;
    }

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name">Name of sound</param>
    /// <param name="fadeOutTime">Time of fade in (seconds)</param>
    /// <returns>Played sound</returns>
    public Sound Stop(string name, float fadeOutTime)
    {
        Sound s = this.Find(name);
        if (s != null)
        {
            StartCoroutine(FadeOut(s.Source, fadeOutTime));
        }
        return s;
    }

    /// <summary>
    /// Fade in
    /// </summary>
    /// <param name="audioSource">Source to play </param>
    /// <param name="FadeTime">Time of fade in (seconds)</param>
    /// <returns></returns>
    private IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < maxVolumeMusic)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.volume = maxVolumeMusic;
    }
    /// <summary>
    /// Fade out
    /// </summary>
    /// <param name="audioSource">Source to play </param>
    /// <param name="FadeTime">Time of fade out (seconds)</param>
    /// <returns></returns>
    private IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
