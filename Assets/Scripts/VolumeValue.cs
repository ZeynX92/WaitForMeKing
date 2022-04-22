using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public AudioSource audioSrc;
    public float musicVolume = 1f;
    public Slider slider;

    void Update()
    {
        audioSrc.volume = slider.value / 100;
    }
}
