using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VolumeSlider : MonoBehaviour
{

    public Slider volumeSlider;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
