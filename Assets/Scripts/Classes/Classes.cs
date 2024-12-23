using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}
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
    public Rarity Type;
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