using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "ShopData", menuName = "ShopData", order = 1)]
public class ShopData : ScriptableObject
{
    public Texture2D DefaultUnlockedImage;

    public List<Cart> Carts;
    public List<Animal> Animals;
    public List<PowerUp> PowerUps;
}

[Serializable]
public class ShopItem
{
    public string name;
    public string id;
    public int price;
    public Sprite image;
    public string description;
    public bool defaultOn;
    public bool unlocked;
}
