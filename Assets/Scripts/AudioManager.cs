using System;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {
        if (Instance == null)

        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        PlayMusic("Music");
    }


    public void PlayMusic(string name)
    {

        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");

        }

        else

        {
            musicSource.clip = s.clip;
            musicSource.Play();

        }
    }

    public void PlaySFX(string name)
    {

        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)

        {
            Debug.Log("Sound not found");

        }

        else

        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void toggleMusic()
    { 
        musicSource.mute = !musicSource.mute; 
    }

    public void toggleSfX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume) 
    { 
    musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    { sfxSource.volume = volume; }
}
