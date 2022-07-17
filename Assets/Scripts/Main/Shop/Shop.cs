using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject CharacterShopUI;
    public GameObject ItemShopUI;

    public GameObject ShopButton;
    public GameObject InventoryButton;

    public GameObject[] Alerts;

    public void OpenShop()
    {
        ShopButton.SetActive(false);
        InventoryButton.SetActive(false);
        CharacterShopUI.SetActive(true);

        for (int i = 0; i < Alerts.Length; i++)
        {
            Alerts[i].SetActive(false);
        }
    }

    public void CharacterToItem()
    {
        for (int i = 0; i < Alerts.Length; i++)
        {
            Alerts[i].SetActive(false);
        }

        CharacterShopUI.SetActive(false);
        ItemShopUI.SetActive(true);
    }

    public void ItemToCharacter()
    {
        for (int i = 0; i < Alerts.Length; i++)
        {
            Alerts[i].SetActive(false);
        }

        ItemShopUI.SetActive(false);
        CharacterShopUI.SetActive(true);
    }
}
