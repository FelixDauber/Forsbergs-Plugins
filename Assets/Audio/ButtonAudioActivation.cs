using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioActivation : MonoBehaviour
{
    //Activation for Hover, Press Possitive and Negative.

    public string soundName = "1";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<AudioManager>().Play(soundName);
        }
    }
}
