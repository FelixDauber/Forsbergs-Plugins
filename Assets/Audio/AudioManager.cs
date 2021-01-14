using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using System;
using Plugins.ListMenuPlugin.Scripts;

public class AudioManager : MonoBehaviour
{
    UnityEvent<string> onButtonClick;
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.AudioSetup();
        }
    }
    
    public void Start()
    {
        var menuHolder = GetComponent<MenuHolder>();
        menuHolder.menu.onButtonClick.AddListener(Play);
    }
    
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
