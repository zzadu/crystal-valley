using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject CharacterShopUI;
    public GameObject ItemShopUI;

    public GameObject ShopButton;
    public GameObject InventoryButton;

    public void OpenShop()
    {
        ShopButton.SetActive(false);
        InventoryButton.SetActive(false);
        CharacterShopUI.SetActive(true);
    }

    public void CharacterToItem()
    {
        CharacterShopUI.SetActive(false);
        ItemShopUI.SetActive(true);
    }

    public void ItemToCharacter()
    {
        ItemShopUI.SetActive(false);
        CharacterShopUI.SetActive(true);
    }
}
