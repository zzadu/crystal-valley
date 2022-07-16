using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    int crystalCnt;
    int amethystCnt;

    float interval = 10f;

    int crystalAddByLevel;
    int intervalAddByLevel;

    public Text crystalDisplay;

    private void Start()
    {
        crystalCnt = DataController.Instance.gameData.crystalCnt; // ����
        amethystCnt = DataController.Instance.gameData.amethystCnt; // �ڼ���


        if (DataController.Instance.gameData.EndDate != null)
        {
            // ��׶��� ����
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = DateTime.Now - endTime;

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }

        crystalDisplay.text = crystalCnt.ToString();
    }

    // �� ����
    private void OnMouseDown()
    {
        DataController.Instance.LoadGameData();
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

        crystalCnt = DataController.Instance.gameData.crystalCnt;
        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        if (!EventSystem.current.IsPointerOverGameObject() && hit.transform.gameObject.tag != "Suryong") // UI Ŭ���� �и�
        {
            crystalCnt += crystalAddByLevel;
            print(crystalCnt);
        }

        DataController.Instance.gameData.crystalCnt = crystalCnt;
        DataController.Instance.gameData.crystalAddByLevel = crystalAddByLevel;
        DataController.Instance.SaveGameData();

        crystalDisplay.text = crystalCnt.ToString();
    }

    // ���� ���� �� �ð��� ���� ����
    private void FixedUpdate()
    {
        interval -= Time.deltaTime;

        crystalCnt = DataController.Instance.gameData.crystalCnt;
        intervalAddByLevel = DataController.Instance.gameData.intervalAddByLevel;

        if (interval <= 0f)
        {
            crystalCnt += intervalAddByLevel;
            interval = 10f;
        }

        DataController.Instance.gameData.intervalAddByLevel = intervalAddByLevel;
    }

    // ������ �� ������ ����
    public void LevelUp()
    {
        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        crystalAddByLevel += 10;
        DataController.Instance.gameData.crystalAddByLevel = crystalAddByLevel;
        intervalAddByLevel += 1;
        DataController.Instance.gameData.intervalAddByLevel = intervalAddByLevel;
        DataController.Instance.SaveGameData();
    }

    // ��׶��� �� �ð��� ���� ���� - ������ ���� �ð� ���� ���� �ð� ���ؼ� �׸�ŭ ��ȭ ����
    private void OnApplicationFocus(bool focus)
    {
        DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
        TimeSpan time = DateTime.Now - endTime;

        crystalCnt = DataController.Instance.gameData.crystalCnt;
        crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        DataController.Instance.SaveGameData();
    }

    private void Update()
    {
        DataController.Instance.gameData.crystalCnt = crystalCnt;
    }
}
