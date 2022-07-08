using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
    public GameObject showButton;
    public GameObject scrollView;
    public GameObject content;

    int itemCntInInventory;

    public Sprite[] suryongs;
    int[] slots;

    private void Awake()
    {
        // �κ��丮�� �ִ� ������ ����
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        // �κ��丮 ������ ���
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

        // �κ��丮 sprite ����
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
    }

    public void showButtons()
    {
        showButton.SetActive(true);
    }

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
