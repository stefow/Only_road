using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIElement : MonoBehaviour
{
    public Image Image;
    public Sprite HiddenImage;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI ButtonText;

    public GameObject PricePanel;
    public Button BuyButton;

    public void UpdateUIElement(ShopItem shopItem)
    {
        if(shopItem.unlocked)
        {
            Image.sprite = shopItem.image;
            NameText.text = shopItem.name;
            DescriptionText.text = shopItem.description;
            Price.text = shopItem.price.ToString();
            if (shopItem.defaultOn==true)
            {
                //BuyButton.gameObject.SetActive(false);
                ButtonText.text = "Equipped";
                PricePanel.SetActive(false);
            }
            
        }
        else 
        {
            Image.sprite = HiddenImage;
            NameText.text = "????";
            DescriptionText.text = "????";
            Price.text = "????";
        }
        
        

    }

}
