using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crystal : MonoBehaviour
{
    int crystalCnt;
    int amethystCnt;
    float interval = 10f;

    int crystalAddByLevel;
    int intervalAddByLevel;

    private void Start()
    {
        crystalCnt = DataController.Instance.gameData.crystalCnt; // ����
        amethystCnt = DataController.Instance.gameData.amethystCnt; // �ڼ���

        // �� �� ������
        if (DataController.Instance.gameData.crystalAddByLevel == 0)
            crystalAddByLevel = 10;
        else
            crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        // �ð��� ���� ������
        if (DataController.Instance.gameData.intervalAddByLevel == 0)
            intervalAddByLevel = 1;
        else
            intervalAddByLevel = DataController.Instance.gameData.intervalAddByLevel;

        if (DataController.Instance.gameData.EndDate != null)
        {
            // ��׶��� ����
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = DateTime.Now - endTime;

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }
    }

    // �� ����
    private void OnMouseDown()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

        if (!EventSystem.current.IsPointerOverGameObject() && hit.transform.gameObject.tag != "Suryong") // UI Ŭ���� �и�
        {
            crystalCnt += crystalAddByLevel;
            DataController.Instance.gameData.crystalCnt = crystalCnt;
        }
    }

    // ���� ���� �� �ð��� ���� ����
    private void FixedUpdate()
    {
        interval -= Time.deltaTime;

        if (interval <= 0f)
        {
            crystalCnt += intervalAddByLevel;
            interval = 10f;
        }
    }

    // ������ �� ������ ����
    public void LevelUp()
    {
        DataController.Instance.gameData.crystalAddByLevel += 10;
        DataController.Instance.gameData.intervalAddByLevel += 1;
    }

    // ��׶��� �� �ð��� ���� ���� - ������ ���� �ð� ���� ���� �ð� ���ؼ� �׸�ŭ ��ȭ ����
    private void OnApplicationFocus(bool focus)
    {
        DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
        TimeSpan time = DateTime.Now - endTime;

        crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
    }
}
