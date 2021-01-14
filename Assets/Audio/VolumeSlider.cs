using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class VolumeSlider : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioManager audioManager;

    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject.GetComponent<AudioManager>();
        volumeSlider.value = audioManager.sounds[0].volume;
    }

    // Update is called once per frame
    void Update()
    {
        audioManager.sounds[0].volume = volumeSlider.value;
    }
}
