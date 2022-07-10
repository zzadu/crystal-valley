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

        // �κ��丮 �ʱ�ȭ
        // DataController.Instance.gameData.itemCntInInventory = 0;
        // DataController.Instance.gameData.slots = new int[36];

        // �κ��丮�� �ִ� ������ ����
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        for (int i = 0; i < inventoryCnt / 4; i++)
        {
            GameObject slot = Instantiate(slotLine);
            slot.transform.SetParent(content.transform);
            slot.tag = (i + 1).ToString();
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
