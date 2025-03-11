using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonFunctions : MonoBehaviour
{
    public bool MusicEnabled;
    public bool SoundEnabled;

    public Sprite mutedMusic;
    public Sprite mutedSound;
    public Sprite soundOn;
    public Sprite musicOn;

    public Button soundButton;
    public Button musicButton;
    public AudioSource musicSource;
    public List<AudioSource> soundSource;
    public GameObject LoadingPanel;
    public void OpenScene(int index)
    {
        LoadingPanel.SetActive(true);
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MusicOptions()
    {
        if (MusicEnabled)
        {
            musicSource.volume = 0;
            musicButton.image.sprite = mutedMusic;
            MusicEnabled = false;
        }
        else
        {
            musicButton.image.sprite = musicOn;
            MusicEnabled = true;
            musicSource.volume = 0.5f;
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
            soundButton.image.sprite = soundOn;
            SoundEnabled = true;
            foreach (AudioSource source in soundSource)
            {
                source.volume = 0.8f;
            }
        }
    }
    public void SlideDownPanel(RectTransform Panel)
    {
        Panel.localPosition = new Vector2(0, 450f);
        Panel.gameObject.SetActive(true);

        StartCoroutine(MOveObject(Panel, new Vector2(0, 0),false));
        
    }

    public void SlideUpPanel(RectTransform Panel)
    {
        StartCoroutine(MOveObject(Panel, new Vector2(0, 450f), true));
    }

    private IEnumerator MOveObject( RectTransform panel, Vector2 destination,bool hideOnEnd)
    {
        while (panel.transform.localPosition.y!=destination.y)
        {
            panel.transform.localPosition = Vector2.MoveTowards(panel.transform.localPosition, destination, 1600 * Time.deltaTime);
            yield return null;
        }
        panel.gameObject.SetActive(!hideOnEnd);
    }
}