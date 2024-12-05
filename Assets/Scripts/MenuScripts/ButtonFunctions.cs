using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonFunctions : MonoBehaviour
{
    public Player player;
    public Destroyer destroyer;
    
    public bool MusicEnabled=true;
    public bool SoundEnabled=true;

    //slike
    public Sprite mutedMusic;
    public Sprite mutedSound;
    public Sprite soundOn;
    public Sprite musicOn;

    public Button soundButton;
    public Button musicButton;
    public AudioSource musicSource;
    public List<AudioSource> soundSource;
    private Settings settings;
    private void Start()
    {
        settings = Settings.LoadSettings();
        MusicEnabled=settings.musicEnabled;
        SoundEnabled=settings.soundEnabled;
        if (MusicEnabled)
        {
            musicButton.image.sprite = musicOn;
            MusicEnabled = true;
        }
        else
        {
            musicSource.volume = 0;
            musicButton.image.sprite = mutedMusic;
            MusicEnabled = false;
        }

        if (SoundEnabled)
        {
            soundButton.image.sprite = soundOn;
            SoundEnabled = true;
        }
        else
        {
            foreach (AudioSource source in soundSource)
            {
                source.volume = 0;
            }
            soundButton.image.sprite = mutedSound;
            SoundEnabled = false;
        }
    }


    public void OpenScene(int index)
    {
        //settings.musicEnabled = MusicEnabled;
        //settings.soundEnabled = SoundEnabled;
        //settings.SaveSettings();
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        //settings.musicEnabled = MusicEnabled;
        //settings.soundEnabled = SoundEnabled; 
        //settings.SaveSettings();
        Application.Quit();
    }
    public void EnableObject(GameObject target)
    {
        target.SetActive(true);
    }
    public void DisableObject(GameObject target)
    {
        target.SetActive(false);
    }
    public void StopTime(bool Start)
    {
        player.start = Start;
        destroyer.start = Start;
    }
    public void MusicOptions()
    { 
        if(MusicEnabled)
        {
            musicSource.volume = 0;
            musicButton.image.sprite = mutedMusic;
            MusicEnabled = false;
        }
        else
        {
            musicButton.image.sprite = musicOn;
            MusicEnabled=true;
            musicSource.volume=0.5f;
        }
    }
    public void SoundOptions()
    {
        if (SoundEnabled)
        {
            foreach (AudioSource source in soundSource)
            {
                source.volume = 0;
            }
            soundButton.image.sprite = mutedSound;
            SoundEnabled = false;
        }
        else
        {
            soundButton.image.sprite= soundOn;
            SoundEnabled=true;
            foreach (AudioSource source in soundSource)
            {
                source.volume = 0.8f;
            }
        }
    }
    
}
