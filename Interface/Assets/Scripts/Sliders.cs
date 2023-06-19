using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    private AudioSource audioSource;
    private float someSoundVolume = 1f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = someSoundVolume;
    }
    public void SetVolume(float vol)
    {
        someSoundVolume = vol;
    }
}
