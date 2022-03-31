using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu: MonoBehaviour {
    [SerializeField] 
    private AudioSettings audioSettings; 
    
    [SerializeField] 
    private Slider volumeSlider;

    public void Start() {
        volumeSlider.value = audioSettings.GetInstance().volume;
    }

    public void ChangeVolume() {
        audioSettings.GetInstance().volume = volumeSlider.value;
    }
}