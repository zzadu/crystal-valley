using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
    public GameObject scrollView;
    public GameObject content;
    public GameObject ShopButton;
    public GameObject InventoryButton;

    int itemCntInInventory;

    public Sprite[] suryongs;
    int[] slots;

    private void Awake()
    {
        // 인벤토리에 있는 아이템 개수
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        // 인벤토리 아이템 목록
        if (DataController.Instance.gameData.slots.Length == 0)
        {
            DataController.Instance.gameData.slots = new int[36];
            DataController.Instance.SaveGameData();
        }
        slots = DataController.Instance.gameData.slots;
    }

    public void showScroll()
    {
        scrollView.SetActive(true);

        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
        slots = DataController.Instance.gameData.slots;

        // 인벤토리 sprite 변경
        for (int i = 0; i < itemCntInInventory; i++)
        {
            GameObject slot = content.transform.GetChild(i / 4 + 1).GetChild(i % 4).GetChild(0).gameObject;
            slot.GetComponent<Image>().sprite = suryongs[slots[i] - 1];
            Color temp = slot.GetComponent<Image>().color;
            temp.a = 255;
            slot.GetComponent<Image>().color = temp;

            slot.tag = "Untagged";
        }

        gameObject.SetActive(false);
        ShopButton.SetActive(false);
    }

    public void Close()
    {
        scrollView.SetActive(false);
        InventoryButton.SetActive(true);
        ShopButton.SetActive(true);
    }

    public void ClosePopup()
    {
        scrollView.SetActive(false);
    }
}
