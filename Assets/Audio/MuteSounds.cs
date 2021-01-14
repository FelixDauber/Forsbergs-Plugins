using System;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace Audio
{
    public class MuteSounds : MonoBehaviour
    {
        public Slider volumeSlider;
        private float lastVolumeSetting;
        private bool isMuted;
        
        [ContextMenu("MuteAllMenuButtonSounds")] 
        public void MuteAllMenuButtonSounds()
        {
            isMuted = !isMuted;
            if (isMuted) { 
                lastVolumeSetting = volumeSlider.value;
                volumeSlider.value = 0;
            } else { 
                volumeSlider.value = lastVolumeSetting;
            }
        }
    }
}