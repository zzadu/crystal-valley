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
    
    //bgm 볼륨조절 슬라이더
    private void Start()
    {
        volumeSlider.value = backVolume;
        backGroundMusic.volume = volumeSlider.value;
    }
    void Update()
    {
        backGroundMusic.volume = volumeSlider.value;
    }
     
    //bgm on/off버튼 함수
    public void musicOnOff()
    {
        if (backGroundMusic.isPlaying) backGroundMusic.Pause();
        else backGroundMusic.Play();
    }
}


