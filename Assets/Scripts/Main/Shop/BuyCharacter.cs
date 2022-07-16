using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacter : MonoBehaviour
{
    public GameObject[] suryongPrefabs;
    public Sprite[] suryongs;

    public GameObject range;
    BoxCollider2D collider;

    int inventoryCnt;
    int itemCntInInventory;
    int[] slots = new int[36];

    int mainCnt;
    int itemCntInMain;
    int[] mains = new int[40];

    public GameObject NoSlot;
    public GameObject InventoryAlert;
    public GameObject NoInventoryAlert;
    public GameObject CrystalAlert;

    public GameObject Price;

    int crystalCnt;
    public Text crystalDisplay;

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

        int price = Int32.Parse(Price.GetComponent<Text>().text);

        if (itemCntInInventory >= inventoryCnt && itemCntInMain >= mainCnt) // Ȩ, �κ��丮 �� �� �� á�� ��
        {
            StartCoroutine(IShowAlert(NoSlot, NoInventoryAlert));
        }
        else if (itemCntInMain >= mainCnt) // Ȩ�� �� á�� �� -> �κ��丮 �̵�
        {
            if (crystalCnt - price >= 0)
            {
                StartCoroutine(IShowAlert(NoSlot, InventoryAlert));

                GameObject content = GameObject.Find("InventoryUI").transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
                GameObject slot = content.transform.GetChild(itemCntInInventory / 4 + 1).GetChild(itemCntInInventory % 4).GetChild(0).gameObject; // Line, Slot, ItemImage ����

                // �ش� ���� sprite ����
                slot.GetComponent<Image>().sprite = suryongs[Int32.Parse(gameObject.name) - 1];
                Color temp = slot.GetComponent<Image>().color;
                temp.a = 255;
                slot.GetComponent<Image>().color = temp;

                // slot tag ����
                slot.tag = "Untagged";

                // �κ��丮 ���빰 ����
                slots = DataController.Instance.gameData.slots;
                slots[itemCntInInventory] = Int32.Parse(gameObject.name);

                // �κ��丮 �� ������ ���� ����
                itemCntInInventory++;

                crystalCnt -= price;

                DataController.Instance.gameData.slots = slots;
                DataController.Instance.gameData.itemCntInInventory = itemCntInInventory;
            }
            else
            {
                StartCoroutine(IShowAlert(NoSlot, CrystalAlert));
            }
        }
        else
        {
            print(crystalCnt);
            if (crystalCnt - price >= 0)
            {
                // ������ ��ġ ���� ����
                Vector3 pos = range.transform.position;
                float x = collider.bounds.size.x;
                float y = collider.bounds.size.y;

                x = UnityEngine.Random.Range(-x / 2, x / 2);
                y = UnityEngine.Random.Range(-y / 2, y / 2);
                Vector3 randomPos = new Vector3(x, y, -2);

                Vector3 spawnPos = pos + randomPos;
                spawnPos.z = -2;

                GameObject sr = Instantiate(suryongPrefabs[Int32.Parse(gameObject.name) - 1]);
                sr.transform.position = spawnPos;

                crystalCnt -= price;

                // Ŭ�� �̸� ����
                sr.name = gameObject.name;

                // Ȩ ��ġ ��� ����
                mains[itemCntInMain] = Int32.Parse(gameObject.name);
                itemCntInMain++;

                DataController.Instance.gameData.mains = mains;
                DataController.Instance.gameData.itemCntInMain = itemCntInMain;
            }
            else
            {
                print("����");
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
}