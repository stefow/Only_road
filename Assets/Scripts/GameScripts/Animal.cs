using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    AudioSource AnimalSound;
    public AudioClip Happy, Sad, Danger;
    void Start()
    {
        AnimalSound =this.GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    public void PlayHappy() 
    {
        AnimalSound.clip = Happy;
        AnimalSound.Play();
    }
    public void PlaySad()
    {
        AnimalSound.clip = Sad;
        AnimalSound.Play();
    }
    public void PlayDanger()
    {
        AnimalSound.clip = Danger;
        AnimalSound.Play();
    }
}
