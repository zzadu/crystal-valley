using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryToHome : MonoBehaviour
{
    public GameObject[] suryongPrefab;
    public GameObject range;
    BoxCollider2D collider;

    int itemCntInInventory;
    int[] slots = new int[36];

    int mainCnt;
    int itemCntInMain;
    int[] mains = new int[40];

    public GameObject content;
    public Sprite[] suryongs;

    public GameObject NoSlot;
    public GameObject MainAlert;

    private void Awake()
    {
        // 랜덤 생성 범위
        collider = range.GetComponent<BoxCollider2D>();

        // 인벤토리에 있는 아이템 개수
        itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;

        // 인벤토리 아이템 목록
        if (DataController.Instance.gameData.slots.Length == 0)
        {
            DataController.Instance.gameData.slots = new int[36];
        }
        else
        {
            slots = DataController.Instance.gameData.slots;
        }

        // 메인 배치 가능 수
        if (DataController.Instance.gameData.mainCnt == 0)
        {
            DataController.Instance.gameData.mainCnt = 15;
        }
        else
        {
            mainCnt = DataController.Instance.gameData.mainCnt;
        }

        // 홈에 있는 아이템 개수
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;

        // 홈 아이템 목록
        if (DataController.Instance.gameData.mains.Length == 0)
        {
            DataController.Instance.gameData.mains = new int[40];
        }
        else
        {
            mains = DataController.Instance.gameData.mains;
        }
    }

    public void InventoryTo()
    {
        if (itemCntInMain < mainCnt)
        {
            // 수룡이 위치 랜덤 생성
            Vector3 pos = range.transform.position;
            float x = collider.bounds.size.x;
            float y = collider.bounds.size.y;

            x = Random.Range(-x / 2, x / 2);
            y = Random.Range(-y / 2, y / 2);
            Vector3 randomPos = new Vector3(x, y, -1);

            Vector3 spawnPos = pos + randomPos;

            // 인벤토리 제거
            itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
            itemCntInInventory--;
            DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;

            for (int i = InventoryEvent.slotNum; i < slots.Length - 1; i++)
            {
                slots[i] = slots[i + 1];
            }

            // 화면 배치
            GameObject su = Instantiate(suryongPrefab[0]);
            su.transform.position = spawnPos;

            // 클론 이름 변경
            su.name = (InventoryEvent.select).ToString();

            DataController.Instance.SaveGameData();

            gameObject.SetActive(false);

            // 인벤토리 sprite 변경
            for (int i = 0; i <= itemCntInInventory; i++)
            {
                if (i < itemCntInInventory)
                {
                    GameObject slot = content.transform.GetChild(i / 4 + 1).GetChild(i % 4).GetChild(0).gameObject;


                    print(slots[i] - 1);
                    slot.GetComponent<Image>().sprite = suryongs[slots[i] - 1];
                    Color temp = slot.GetComponent<Image>().color;
                    temp.a = 255;
                    slot.GetComponent<Image>().color = temp;

                    slot.tag = "Untagged";
                }
                else
                {
                    GameObject slot = content.transform.GetChild(i / 4 + 1).GetChild(i % 4).GetChild(0).gameObject;
                    slot.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                    slot.tag = "empty";
                }
            }

            // 홈 배치 목록 삽입
            mains[itemCntInMain++] = InventoryEvent.select;
            DataController.Instance.gameData.mains = mains;
            DataController.Instance.gameData.itemCntInMain = itemCntInMain;
            DataController.Instance.SaveGameData();
        }
        else
        {
            StartCoroutine(IShowAlert(NoSlot, MainAlert));
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
