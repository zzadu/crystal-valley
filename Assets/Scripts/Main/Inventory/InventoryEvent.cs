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

    private void Start()
    {
        // 인벤토리 개수
        if (DataController.Instance.gameData.inventoryCnt == 0)
        {
            DataController.Instance.gameData.inventoryCnt = inventoryCnt;
        }
        else
        {
            inventoryCnt = DataController.Instance.gameData.inventoryCnt;
        }

        // 인벤토리에 있는 아이템 개수
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        // 인벤토리 아이템 목록
        if (DataController.Instance.gameData.slots.Length == 0)
        {
            DataController.Instance.gameData.slots = new int[36];
        }
        else { 
            slots = DataController.Instance.gameData.slots; 
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
            print(itemCntInInventory);
            GameObject content = GameObject.Find("InventoryUI").transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
            GameObject slot = content.transform.GetChild(itemCntInInventory / 4 + 1).GetChild(itemCntInInventory % 4).GetChild(0).gameObject; // Line, Slot, ItemImage 순서

            print(UIFollowCharacter.select);
            // 해당 슬롯 sprite 변경
            slot.GetComponent<Image>().sprite = suryongs[UIFollowCharacter.select - 1];
            Color temp = slot.GetComponent<Image>().color;
            temp.a = 255;
            slot.GetComponent<Image>().color = temp;

            // slot tag 변경
            slot.tag = "Untagged";

            // 인벤토리 내용물 변경
            slots[itemCntInInventory] = UIFollowCharacter.select;
            DataController.Instance.gameData.slots = slots;

            // 인벤토리 안 아이템 개수 변경
            itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
            print(itemCntInInventory);
            itemCntInInventory++;
            print(itemCntInInventory);
            DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;

            // 홈 화면 수룡이 삭제
            Destroy(UIFollowCharacter.selection); // 추후 프리팹으로 변경 시 Destroy

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
