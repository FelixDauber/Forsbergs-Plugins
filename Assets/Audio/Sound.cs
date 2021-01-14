using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(1.0f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public void AudioSetup()
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.name = name;

        // public float volume {get => volume; set => ;}
    }
}

