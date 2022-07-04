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
        crystalCnt = DataController.Instance.gameData.crystalCnt; // 수정
        amethystCnt = DataController.Instance.gameData.amethystCnt; // 자수정

        // 탭 시 증가량
        if (DataController.Instance.gameData.crystalAddByLevel == 0)
            crystalAddByLevel = 10;
        else
            crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        // 시간에 따른 증가량
        if (DataController.Instance.gameData.intervalAddByLevel == 0)
            intervalAddByLevel = 1;
        else
            intervalAddByLevel = DataController.Instance.gameData.intervalAddByLevel;

        if (DataController.Instance.gameData.EndDate != null)
        {
            // 백그라운드 증가
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = DateTime.Now - endTime;

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }
    }

    // 탭 증가
    private void OnMouseDown()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

        if (!EventSystem.current.IsPointerOverGameObject() && hit.transform.gameObject.tag != "Suryong") // UI 클릭과 분리
        {
            crystalCnt += crystalAddByLevel;
            DataController.Instance.gameData.crystalCnt = crystalCnt;
        }
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
        TimeSpan time = DateTime.Now - endTime;

        crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
    }
}
