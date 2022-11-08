using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioClip[] soundEffects, music;
    [SerializeField] AudioSource audioSourceSoundEffect, audioSourceMusic;
    [SerializeField] float generalVolume;
    public void SetGeneralVolume(float volume)
    {
        generalVolume = volume;
        UpdateVolume();
    }

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePitch(float pitch)
    {
        audioSourceMusic.pitch = pitch;
    }

    public void UpdateVolume()
    {
        audioSourceSoundEffect.volume *= generalVolume;
        audioSourceMusic.volume *= generalVolume;
    }
    public void ChangeVolumeSoundEFFect(float volume)
    {
        audioSourceSoundEffect.volume = volume * generalVolume;

    }
    public void ChangeVolumeMusic(float volume)
    {
        audioSourceMusic.volume = volume * generalVolume;

    }
    public void PlayMusic(int index)
    {
        StopMusic();
        if (index < music.Length)
        {
            audioSourceMusic.clip = music[index];
        }
        else
        {
            audioSourceMusic.clip = music[2];
        }

        audioSourceMusic.Play();
    }
    public void StopMusic()
    {
        audioSourceMusic.Stop();
    }
    public void playSoundEffect(int index, float volumeScale)
    {
        audioSourceSoundEffect.PlayOneShot(soundEffects[index], volumeScale);
    }


}
