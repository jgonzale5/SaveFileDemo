﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip loseSound;

    public Toggle muteToggle;
    public AudioSource MusicSource;
    public AudioClip music;

    private void Awake()
    {
        int val = PlayerPrefs.GetInt("MusicMuted");

        MusicSource.mute = (val == 1);

        //Is the same as
        //if (val == 1)
        //{
        //    MusicSource.mute = true;
        //}
        //else
        //{
        //    MusicSource.mute = false;
        //}

        //And
        //MusicSource.mute = (val == 1) ? true : false;

        muteToggle.isOn = MusicSource.mute;
    }

    public void PlayLoseSound()
    {
        SFXSource.PlayOneShot(loseSound);
    }

    public void MuteMusic()
    {
        MusicSource.mute = true;
    }

    public void UnmuteMusic()
    {
        MusicSource.mute = false;
    }

    public void SetMute(bool to)
    {
        MusicSource.mute = to;


        int val = ((to) ? 1 : 0);

        //Is the equivalent of 
        //if (to == true)
        //{
        //    val = 1;
        //}
        //else
        //{
        //    val = 0;
        //}

        PlayerPrefs.SetInt("MusicMuted", val);
    }

    public void PauseMusic()
    {
        MusicSource.Pause();
    }

    public void UnPauseMusic()
    {
        MusicSource.UnPause();
    }
}
