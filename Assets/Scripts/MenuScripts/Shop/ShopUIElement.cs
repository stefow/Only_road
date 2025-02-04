using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ShopUIElement : MonoBehaviour
{
    private Shop shop;
    private ShopItem shopItem;
    private GameData gameData;

    //UI
    public Image Image;
    public TextMeshProUGUI Equipped;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI ButtonText;
    public GameObject PricePanel;
    public Button BuyButton;
    public Button EquipButton;
    
    public void Awake()
    {
        BuyButton.onClick.AddListener(Buy);
        EquipButton.onClick.AddListener(Equip);
    }
    public void SetData(Shop shop,GameData data, ShopItem shopItem)
    {
        this.shop = shop;
        this.gameData = data;
        this.shopItem = shopItem;
        UpdateUIElement();
    }
    public void UpdateUIElement()
    {
        Image.sprite = shopItem.image;
        NameText.text = shopItem.name;
        DescriptionText.text = shopItem.description;
        PriceText.text = shopItem.price.ToString();
        if (shopItem is Animal)
        {
            if (gameData.EquippedAnimal == shopItem.id )
            {
                Equip();
            }
            else if (gameData.OwnedAnimals.Contains(shopItem.id))
            {
                Owned();
            }
        }
        else if (shopItem is Cart)
        {
            if (gameData.EquippedCart == shopItem.id)
            {
                Equip();
            }
            else if (gameData.OwnedCarts.Contains(shopItem.id))
            {
                Owned();
            }
        }
    }
    public void Buy()
    {
        if(shopItem.price<=gameData.Coins)
        {
            gameData.Coins-=shopItem.price;
            shop.UpdateUI();
            if(shopItem is Animal)
            {
                gameData.OwnedAnimals.Add(shopItem.id);
            }
            if (shopItem is Cart)
            {
                gameData.OwnedCarts.Add(shopItem.id);
            }
            Owned();
        }
    }
    public void Equip()
    {
        if (shopItem is Animal)
        {
            gameData.EquippedAnimal = shopItem.id;
            shop.EquippedAnimalUI?.Owned();
            shop.EquippedAnimalUI = this;
            Animal animal = shopItem as Animal;
            shop.SpawnAnimal(animal.Prefab);
        }
        else if (shopItem is Cart)
        {
            gameData.EquippedCart = shopItem.id;
            shop.EquippedCartUI?.Owned();
            shop.EquippedCartUI = this;
        }
        PricePanel.SetActive(false);
        BuyButton.gameObject.SetActive(false);
        EquipButton.gameObject.SetActive(false);
        Equipped.gameObject.SetActive(true);
        gameData.Save();
    }
    public void Owned()
    {
        PricePanel.SetActive(false);
        BuyButton.gameObject.SetActive(false);
        EquipButton.gameObject.SetActive(true);
        gameData.Save();
    }
    

}
