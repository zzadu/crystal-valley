using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel; // �� �� ������
        intervalAddByLevel = DataController.Instance.gameData.intervalAddByLevel; // �ð��� ���� ������

        if (DataController.Instance.gameData.EndDate != null)
        {
            // ��׶��� ����
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = endTime - DateTime.Now;
            print(time.ToString());

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }
    }

    // �� ����
    private void OnMouseDown()
    {
        crystalCnt += crystalAddByLevel;
        DataController.Instance.gameData.crystalCnt = crystalCnt;
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
        TimeSpan time = endTime - DateTime.Now;
        print(time);

        crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
    }
}
