using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cart : ShopItem
{
    public GameObject Prefab;

    public Cart()
    {
        id = "C";
    }
}
[Serializable]
public class Animal : ShopItem
{
    public GameObject Prefab;
    public AudioClip Happy;
    public AudioClip Danger;
    public AudioClip Sad;

    AudioSource AnimalSound;
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
    public Animal()
    {
        id = "A";
    }

}
[Serializable]
public class PowerUp : ShopItem
{
    public GameObject Prefab;
    public PowerUp()
    {
        id = "B";
    }

}