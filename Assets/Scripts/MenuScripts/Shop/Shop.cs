using System.Collections;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
public class Shop : MonoBehaviour
{
    public ShopData ShopData;

    public GameObject AnimalsUIprefab;
    public GameObject CartsUIprefab;
    public GameObject SpeciallsUIprefab;

    public GameObject AnimalsPanel;
    public GameObject CartsPanel;
    public GameObject SpecialPanel;
    public TMP_Text CoinsText;
    private GameData gameData;

    public ShopUIElement EquippedAnimalUI;
    public ShopUIElement EquippedCartUI;

    public GameObject EquippedAnimalPrefab;
    public GameObject EquippedCartPrefab;

    public Transform AnimalPosition;
    
    public void Start()
    {
        gameData = GameData.GetInstance();
        CoinsText.text = gameData.Coins.ToString();
        UpdateShopItems();
    }
    public void UpdateShopItems()
    {
        foreach (Animal animal in ShopData.Animals)
        {
            GameObject prefab = Instantiate(AnimalsUIprefab, AnimalsPanel.transform);
            ShopUIElement shopUIElement = prefab.GetComponent<ShopUIElement>();
            shopUIElement.SetData(this,gameData,animal);
        }
        foreach (Cart cart in ShopData.Carts)
        {
            GameObject prefab = Instantiate(CartsUIprefab, CartsPanel.transform);
            ShopUIElement shopUIElement = prefab.GetComponent<ShopUIElement>();
            shopUIElement.SetData(this, gameData, cart);
        }
        foreach (PowerUp powerUp in ShopData.PowerUps)
        {
            GameObject prefab = Instantiate(SpeciallsUIprefab, SpecialPanel.transform);
            ShopUIElement shopUIElement = prefab.GetComponent<ShopUIElement>();
            shopUIElement.SetData(this, gameData, powerUp);
        }
    }
    public void UpdateUI()
    {
        StartCoroutine(AnimateCoins(CoinsText, int.Parse(CoinsText.text), gameData.Coins));
    }
    public void SpawnAnimal(GameObject animal)
    {
        Destroy(EquippedAnimalPrefab);
        EquippedAnimalPrefab = Instantiate(animal, AnimalPosition.position,Quaternion.identity);
        EquippedAnimalPrefab.transform.Rotate(new Vector3(0,-60,0));
    }
    private IEnumerator AnimateCoins (TMP_Text coinText,int current,int target)
    {
        while (current>target)
        {
            current -= 10;
            coinText.text = current.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        coinText.text = target.ToString();
    }
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void HideAllChildrenPanels(GameObject panel)
    {
        foreach (Transform child in panel.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }
}