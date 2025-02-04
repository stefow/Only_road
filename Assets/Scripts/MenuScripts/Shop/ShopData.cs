using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public GameObject FindCartById(string id)
    {
        foreach (Cart cart in Carts)
        {
            if (cart.id == id)
            {
                return cart.Prefab;
            }
        }
        return Carts[0].Prefab;
    }
    public GameObject FindAnimalById(string id)
    {
        foreach (Animal animal in Animals)
        {
            if (animal.id == id)
            {
                return animal.Prefab;
            }
        }
        return Animals[0].Prefab;
    }
}

[Serializable]
public class ShopItem
{
    public string name;
    public string id;
    public int price;
    public Sprite image;
    public string description;
}