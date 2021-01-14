using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using System;
using Plugins.ListMenuPlugin.Scripts;

public class AudioManager : MonoBehaviour
{
    //UnityEvent onButtonClick = new UnityEvent();
    UnityEvent<string> onButtonClick;
    public Sound[] sounds;
    private static AudioManager audioManager;

    void Awake()
    {
        if(audioManager != null)
        {
            Debug.LogWarning("Found two menuAudioManagers, destroying one");
            Destroy(this);
        }
        else
        {
            audioManager = this;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.AudioSetup();
        }
    }
    
    public void Start()
    {
        //onButtonClick.AddListener(ButtonSound);
        foreach (var menu in FindObjectsOfType<Plugins.ListMenuPlugin.Scripts.Menu>())
        {
            menu.playSoundOnClick.AddListener(Play);
        }
    }
    
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Update()
    {
        if (onButtonClick != null)
        {
            ButtonSound();
        }
    }
    void ButtonSound()
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
