using System.Collections;
using System.Collections.Generic;
using Plugins.ListMenuPlugin.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public Button button;
    public bool buttonPress;
    public GameObject _button;

    public void Start()
    {
        _button.SetActive(false);
    }
    public void Update()
    {
        AudioPlay();
    }
    public void AudioPlay()
    {
        if (buttonPress)
        {
            _button.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Button1");
        }
        else
        {
            _button.SetActive(false);
            //FindObjectOfType<AudioManager>().Play("Button2");
        }
    }
}
