using Unity.VisualScripting;
using UnityEngine;
public class Shop : MonoBehaviour
{
    public ShopData ShopData;

    public GameObject AnimalsUIprefab;
    public GameObject CartsUIprefab;
    public GameObject SpeciallsUIprefab;

    public GameObject AnimalsPanel;
    public GameObject CartsPanel;
    public GameObject SpecialPanel;

    public void Start()
    {
        UpdateShop();
    }
    public void UpdateShop()
    {
        foreach (Animal animal in ShopData.Animals)
        {
            GameObject prefab = Instantiate(AnimalsUIprefab, AnimalsPanel.transform);
            prefab.GetComponent<ShopUIElement>().UpdateUIElement(animal);
        }
        foreach (Cart cart in ShopData.Carts)
        {
            GameObject prefab = Instantiate(CartsUIprefab, CartsPanel.transform);
            prefab.GetComponent<ShopUIElement>().UpdateUIElement(cart);
        }
        foreach (PowerUp powerUp in ShopData.PowerUps)
        {
            GameObject prefab = Instantiate(SpeciallsUIprefab, SpecialPanel.transform);
            prefab.GetComponent<ShopUIElement>().UpdateUIElement(powerUp);
        }
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