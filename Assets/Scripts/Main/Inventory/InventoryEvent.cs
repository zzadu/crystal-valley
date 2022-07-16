using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryEvent : MonoBehaviour
{
    int inventoryCnt;
    int itemCntInInventory;

    public Sprite[] suryongs;
    int[] slots = new int[36];

    public static int select;
    public static int slotNum;

    int itemCntInMain;
    int[] mains = new int[40];

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
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
        inventoryCnt = DataController.Instance.gameData.inventoryCnt;

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
            slots = DataController.Instance.gameData.slots;
            slots[itemCntInInventory] = UIFollowCharacter.select;

            // �κ��丮 �� ������ ���� ����
            itemCntInInventory++;

            int remove = 0;
            mains = DataController.Instance.gameData.mains;

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

            // Ȩ ȭ�� ������ ����
            Destroy(UIFollowCharacter.selection); // ���� ���������� ���� �� Destroy

            DataController.Instance.gameData.slots = slots;
            DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;
            DataController.Instance.gameData.itemCntInMain = itemCntInMain;
            DataController.Instance.gameData.mains = mains;
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
