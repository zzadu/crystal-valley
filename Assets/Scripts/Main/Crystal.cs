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
        crystalCnt = DataController.Instance.gameData.crystalCnt; // 수정
        amethystCnt = DataController.Instance.gameData.amethystCnt; // 자수정

        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel; // 탭 시 증가량
        intervalAddByLevel = DataController.Instance.gameData.intervalAddByLevel; // 시간에 따른 증가량

        if (DataController.Instance.gameData.EndDate != null)
        {
            // 백그라운드 증가
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = endTime - DateTime.Now;
            print(time.ToString());

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }
    }

    // 탭 증가
    private void OnMouseDown()
    {
        crystalCnt += crystalAddByLevel;
        DataController.Instance.gameData.crystalCnt = crystalCnt;
    }

    // 게임 실행 중 시간에 따른 증가
    private void FixedUpdate()
    {
        interval -= Time.deltaTime;

        if (interval <= 0f)
        {
            crystalCnt += intervalAddByLevel;
            interval = 10f;
        }
    }

    // 레벨업 시 증가량 증가
    public void LevelUp()
    {
        DataController.Instance.gameData.crystalAddByLevel += 10;
        DataController.Instance.gameData.intervalAddByLevel += 1;
    }

    // 백그라운드 중 시간에 따른 증가 - 마지막 접속 시간 현재 접속 시간 구해서 그만큼 재화 증가
    private void OnApplicationFocus(bool focus)
    {
        DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
        TimeSpan time = endTime - DateTime.Now;
        print(time);

        crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
    }
}
