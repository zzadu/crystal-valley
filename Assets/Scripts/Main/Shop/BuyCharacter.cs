using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacter : MonoBehaviour
{
    public GameObject suryongPrefabs;
    public Sprite suryongs;

    public GameObject range;
    BoxCollider2D collider;

    int inventoryCnt;
    int itemCntInInventory;
    int[] slots;

    int mainCnt;
    int itemCntInMain;
    int[] mains;

    public GameObject NoSlot;
    public GameObject InventoryAlert;
    public GameObject NoInventoryAlert;
    public GameObject CrystalAlert;

    public GameObject Price;

    int crystalCnt;
    public Text crystalDisplay;

    int[] heart;

    int userExp;

    private void Start()
    {
        collider = range.GetComponent<BoxCollider2D>();
        crystalCnt = DataController.Instance.gameData.crystalCnt;
    }

    public void OnClickBuyBtn()
    {
        DataController.Instance.LoadGameData();
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
        inventoryCnt = DataController.Instance.gameData.inventoryCnt;
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;
        mainCnt = DataController.Instance.gameData.mainCnt;
        crystalCnt = DataController.Instance.gameData.crystalCnt;
        heart = DataController.Instance.gameData.heart;
        mains = DataController.Instance.gameData.mains; 

        int price = Int32.Parse(Price.GetComponent<Text>().text);

        if (itemCntInInventory >= inventoryCnt && itemCntInMain >= mainCnt) // 홈, 인벤토리 둘 다 꽉 찼을 때
        {
            StartCoroutine(IShowAlert(NoSlot, NoInventoryAlert));
        }
        else if (itemCntInMain >= mainCnt) // 홈만 꽉 찼을 때 -> 인벤토리 이동
        {
            if (crystalCnt - price >= 0) // 구매 가능
            {
                StartCoroutine(IShowAlert(NoSlot, InventoryAlert));

                GameObject content = GameObject.Find("InventoryUI").transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
                GameObject slot = content.transform.GetChild(itemCntInInventory / 4 + 1).GetChild(itemCntInInventory % 4).GetChild(0).gameObject; // Line, Slot, ItemImage 순서

                // 해당 슬롯 sprite 변경
                slot.GetComponent<Image>().sprite = suryongs;
                Color temp = slot.GetComponent<Image>().color;
                temp.a = 255;
                slot.GetComponent<Image>().color = temp;

                // slot tag 변경
                slot.tag = "Untagged";

                // 인벤토리 내용물 변경
                slots = DataController.Instance.gameData.slots;
                slots[itemCntInInventory] = Int32.Parse(gameObject.name);

                // 인벤토리 안 아이템 개수 변경
                itemCntInInventory++;

                crystalCnt -= price;

                // 친밀도 증가
                if (heart[Int32.Parse(gameObject.name) - 1] <= 90)
                {
                    heart[Int32.Parse(gameObject.name) - 1] += 10;
                }

                DataController.Instance.gameData.heart = heart;
                DataController.Instance.gameData.slots = slots;
                DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;

                addExp();
            }
            else // 구매 불가능
            {
                StartCoroutine(IShowAlert(NoSlot, CrystalAlert));
            }
        }
        else
        {
            print(crystalCnt);
            if (crystalCnt - price >= 0) // 구매 가능
            {
                // 수룡이 위치 랜덤 생성
                Vector3 pos = range.transform.position;
                float x = collider.bounds.size.x;
                float y = collider.bounds.size.y;

                x = UnityEngine.Random.Range(-x / 2, x / 2);
                y = UnityEngine.Random.Range(-y / 2, y / 2);
                Vector3 randomPos = new Vector3(x, y, -2);

                Vector3 spawnPos = pos + randomPos;
                spawnPos.z = -2;

                GameObject sr = Instantiate(suryongPrefabs);
                sr.transform.position = spawnPos;

                crystalCnt -= price;

                // 클론 이름 변경
                sr.name = gameObject.name;

                // 홈 배치 목록 삽입
                mains[itemCntInMain] = Int32.Parse(gameObject.name);
                itemCntInMain++;

                // 친밀도 증가
                if (heart[Int32.Parse(gameObject.name) - 1] <= 90)
                {
                    heart[Int32.Parse(gameObject.name) - 1] += 10;
                }

                DataController.Instance.gameData.heart = heart;

                DataController.Instance.gameData.mains = mains;
                DataController.Instance.gameData.itemCntInMain = itemCntInMain;

                addExp();
            }
            else // 구매 불가능
            {
                print("부족");
                StartCoroutine(IShowAlert(NoSlot, CrystalAlert));
            }
        }

        crystalDisplay.text = crystalCnt.ToString();
        DataController.Instance.gameData.crystalCnt = crystalCnt;
        print("buyC" + crystalCnt);
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

    void addExp()
    {
        userExp = DataController.Instance.gameData.userExp;
        DataController.Instance.gameData.userExp = userExp + 10;
        DataController.Instance.SaveGameData();

        UserLevel.updateExp();
    }
}
