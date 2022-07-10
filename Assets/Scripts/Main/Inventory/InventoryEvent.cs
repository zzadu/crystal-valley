using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryEvent : MonoBehaviour
{
    int inventoryCnt = 12;
    int itemCntInInventory;

    public Sprite[] suryongs;
    int[] slots = new int[36];

    public static int select;
    public static int slotNum;

    int itemCntInMain;
    int[] mains = new int[40];

    private void Start()
    {
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
        else { 
            slots = DataController.Instance.gameData.slots; 
        }

        // Ȩ�� �ִ� ������ ����
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;

        // Ȩ ������ ���
        if (DataController.Instance.gameData.mains.Length == 0)
        {
            DataController.Instance.gameData.mains = new int[40];
        }
        else
        {
            mains = DataController.Instance.gameData.mains;
        }
    }

    public void InventoryToHomePopup()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.GetChild(0).tag != "empty")
        {
            GameObject slot = EventSystem.current.currentSelectedGameObject;
            slot.transform.parent.parent.parent.parent.parent.GetChild(2).gameObject.SetActive(true);
            select = int.Parse(slot.transform.GetChild(0).GetComponent<Image>().sprite.name);
            slotNum = (int.Parse(slot.transform.parent.tag) - 1) * 4 + (int.Parse(slot.tag));
            print("slotNum: " + slotNum);
        }
    }

    public void CharacterToInventory()
    {
        if (itemCntInInventory < inventoryCnt)
        {
            GameObject content = GameObject.Find("InventoryUI").transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
            GameObject slot = content.transform.GetChild(itemCntInInventory / 4 + 1).GetChild(itemCntInInventory % 4).GetChild(0).gameObject; // Line, Slot, ItemImage ����

            // �ش� ���� sprite ����
            slot.GetComponent<Image>().sprite = suryongs[UIFollowCharacter.select - 1];
            Color temp = slot.GetComponent<Image>().color;
            temp.a = 255;
            slot.GetComponent<Image>().color = temp;

            // slot tag ����
            slot.tag = "Untagged";

            // �κ��丮 ���빰 ����
            slots[itemCntInInventory] = UIFollowCharacter.select;
            DataController.Instance.gameData.slots = slots;

            // �κ��丮 �� ������ ���� ����
            itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
            itemCntInInventory++;
            DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;
            print(DataController.Instance.gameData.itemCntInInventory);

            int remove = 0;
            // Ȩȭ�� ���� ����
            for (int i = 0; i < mains.Length - 1; i++)
            {
                if (mains[i] == UIFollowCharacter.select)
                    remove = i;
            }

            for (int i = remove; i < mains.Length - 1; i++)
            {
                mains[i] = mains[i + 1];
            }
            itemCntInMain = DataController.Instance.gameData.itemCntInMain;
            itemCntInMain--;
            DataController.Instance.gameData.itemCntInMain = itemCntInMain;
            DataController.Instance.gameData.mains = mains;

            // Ȩ ȭ�� ������ ����
            Destroy(UIFollowCharacter.selection); // ���� ���������� ���� �� Destroy

            DataController.Instance.SaveGameData();

            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(IShowAlert(gameObject.transform.parent.GetChild(0).gameObject, gameObject.transform.parent.GetChild(0).GetChild(0).gameObject));
        }
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
