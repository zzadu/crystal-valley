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
        crystalCnt = DataController.Instance.gameData.crystalCnt; // 수정
        amethystCnt = DataController.Instance.gameData.amethystCnt; // 자수정


        if (DataController.Instance.gameData.EndDate != null)
        {
            // 백그라운드 증가
            DateTime endTime = DateTime.Parse(DataController.Instance.gameData.EndDate);
            TimeSpan time = DateTime.Now - endTime;

            crystalCnt += (int)(time.Seconds * 0.1 * intervalAddByLevel);
        }

        crystalDisplay.text = crystalCnt.ToString();
    }

    // 탭 증가
    private void OnMouseDown()
    {
        DataController.Instance.LoadGameData();
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

        crystalCnt = DataController.Instance.gameData.crystalCnt;
        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        if (!EventSystem.current.IsPointerOverGameObject() && hit.transform.gameObject.tag != "Suryong") // UI 클릭과 분리
        {
            crystalCnt += crystalAddByLevel;
            print(crystalCnt);
        }

        DataController.Instance.gameData.crystalCnt = crystalCnt;
        DataController.Instance.gameData.crystalAddByLevel = crystalAddByLevel;
        DataController.Instance.SaveGameData();

        crystalDisplay.text = crystalCnt.ToString();
    }

    // 게임 실행 중 시간에 따른 증가
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

    // 레벨업 시 증가량 증가
    public void LevelUp()
    {
        crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;

        crystalAddByLevel += 10;
        DataController.Instance.gameData.crystalAddByLevel = crystalAddByLevel;
        intervalAddByLevel += 1;
        DataController.Instance.gameData.intervalAddByLevel = intervalAddByLevel;
        DataController.Instance.SaveGameData();
    }

    // 백그라운드 중 시간에 따른 증가 - 마지막 접속 시간 현재 접속 시간 구해서 그만큼 재화 증가
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
