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
        // ���� ���� ����
        collider = range.GetComponent<BoxCollider2D>();
    }

    public void InventoryTo()
    {
        DataController.Instance.LoadGameData();

        // Ȩ�� �ִ� ������ ����
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;
        // ���� ��ġ ���� ��
        mainCnt = DataController.Instance.gameData.mainCnt;

        if (itemCntInMain < mainCnt)
        {
            // ������ ��ġ ���� ����
            Vector3 pos = range.transform.position;
            float x = collider.bounds.size.x;
            float y = collider.bounds.size.y;

            x = Random.Range(-x / 2, x / 2);
            y = Random.Range(-y / 2, y / 2);
            Vector3 randomPos = new Vector3(x, y);

            Vector3 spawnPos = pos + randomPos;
            spawnPos.z = -2;

            // �κ��丮 ����
            itemCntInInventory = DataController.Instance.gameData.itemCntInInventory;
            itemCntInInventory--;

            // �κ��丮 ������ ���
            slots = DataController.Instance.gameData.slots;
            for (int i = InventoryEvent.slotNum; i < slots.Length - 1; i++)
            {
                slots[i] = slots[i + 1];
            }

            // ȭ�� ��ġ
            GameObject su = Instantiate(suryongPrefab[0]);
            su.transform.position = spawnPos;

            // Ŭ�� �̸� ����
            print(InventoryEvent.select);
            su.name = (InventoryEvent.select).ToString();

            gameObject.SetActive(false);

            // �κ��丮 sprite ����
            for (int i = 0; i <= itemCntInInventory; i++)
            {
                if (i < itemCntInInventory)
                {
                    GameObject slot = content.transform.GetChild(i / 4 + 1).GetChild(i % 4).GetChild(0).gameObject;

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

            itemCntInMain = DataController.Instance.gameData.itemCntInMain;
            mains = DataController.Instance.gameData.mains;

            // Ȩ ��ġ ��� ����
            mains[itemCntInMain] = InventoryEvent.select;
            itemCntInMain++;

            DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;
            DataController.Instance.gameData.slots = slots;
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
