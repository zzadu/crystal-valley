using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public AudioSource backGroundMusic;

    private float backVolume = 1f;
    
    //bgm �������� �����̴�
    private void Start()
    {
        volumeSlider.value = backVolume;
        backGroundMusic.volume = volumeSlider.value;
    }
    void Update()
    {
        backGroundMusic.volume = volumeSlider.value;
    }
     
    //bgm on/off��ư �Լ�
    public void musicOnOff()
    {
        if (backGroundMusic.isPlaying) backGroundMusic.Pause();
        else backGroundMusic.Play();
    }
}


