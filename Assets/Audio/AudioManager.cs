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
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public void Start()
    {
        //onButtonClick.AddListener(ButtonSound);
        var menuHolder = GetComponent<MenuHolder>();
        menuHolder.menu.onButtonClick.AddListener(Play);
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
