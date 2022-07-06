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
    int[] slots = new int[36];

    private void Awake()
    {
        print(DataController.Instance.gameData.inventoryCnt);

        // �κ��丮 ����
        if (DataController.Instance.gameData.inventoryCnt == 0)
        {
            DataController.Instance.gameData.inventoryCnt = inventoryCnt;
        }
        else
        {
            inventoryCnt = DataController.Instance.gameData.inventoryCnt;
        }

        // �κ��丮�� �ִ� ������ ����
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        // �κ��丮 ������ ���
        if (DataController.Instance.gameData.slots.Length == 0)
        {
            DataController.Instance.gameData.slots = new int[36];
        }
        else
        {
            slots = DataController.Instance.gameData.slots;
        }

        for (int i = 0; i < inventoryCnt / 4; i++)
        {
            GameObject slot = Instantiate(slotLine);
            slot.transform.SetParent(content.transform);
        }

        // �κ��丮 sprite ����
        for (int i = 0; i < itemCntInInventory; i++)
        {
            GameObject slot = content.transform.GetChild(i / 4 + 1).GetChild(i % 4).GetChild(0).gameObject;

            slot.GetComponent<Image>().sprite = suryongs[slots[i] - 1];
            Color temp = slot.GetComponent<Image>().color;
            temp.a = 255;
            slot.GetComponent<Image>().color = temp;
        }
    }

    public void AddSlot()
    {
        if (inventoryCnt <= 24) // �ִ� ĭ�� ������ ���� �ʵ��� ����
        {
            inventoryCnt += 12;
            DataController.Instance.gameData.inventoryCnt = inventoryCnt;
            DataController.Instance.SaveGameData();

            for (int i = 0; i < 3; i++)
            {
                GameObject slot = Instantiate(slotLine);
                slot.transform.SetParent(content.transform);
            }
        }
    }
}
