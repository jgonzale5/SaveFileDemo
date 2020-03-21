using System.Collections;
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
