using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    int inventoryCnt = 12;
    int itemCntInInventory;

    public GameObject slotLine;
    public GameObject content;

    public Sprite[] suryongs;

    public GameObject NoSlot;
    public GameObject AddInventory;
    public GameObject CantAdd;

    public Text price;
    public Button button;
    public GameObject crystal;

    private void Awake()
    {

        // 인벤토리 초기화
        // DataController.Instance.gameData.itemCntInInventory = 0;
        // DataController.Instance.gameData.slots = new int[36];

        inventoryCnt = DataController.Instance.gameData.inventoryCnt;

        if (inventoryCnt == 12)
            price.text = "10000";
        else if (inventoryCnt == 24)
            price.text = "20000";
        else
        {
            button.interactable = false;
            price.text = "";
            crystal.SetActive(false);
        }

        for (int i = 0; i < inventoryCnt / 4; i++)
        {
            GameObject slot = Instantiate(slotLine);
            slot.transform.SetParent(content.transform);
            slot.tag = (i + 1).ToString();
        }
    }

    public void AddSlot()
    {
        inventoryCnt = DataController.Instance.gameData.inventoryCnt;

        if (inventoryCnt <= 24) // 최대 칸의 개수를 넘지 않도록 설정
        {
            inventoryCnt += 12;

            for (int i = 0; i < 3; i++)
            {
                GameObject slot = Instantiate(slotLine);
                slot.transform.SetParent(content.transform);
            }

            price.text = (Int32.Parse(price.text) + 10000).ToString();
            StartCoroutine(IShowAlert(NoSlot, AddInventory));
        }
        if (inventoryCnt == 36)
        {
            button.interactable = false;
            StartCoroutine(IShowAlert(NoSlot, AddInventory));
            price.text = "";
            crystal.SetActive(false);
        }

        DataController.Instance.gameData.inventoryCnt = inventoryCnt;
        DataController.Instance.SaveGameData();
    }

    IEnumerator IShowAlert(GameObject obj1, GameObject obj2)
    {
        obj1.SetActive(true);
        obj2.SetActive(true);
        yield return new WaitForSeconds(2f);
        obj1.SetActive(false);
        obj2.SetActive(false);
    }
}
