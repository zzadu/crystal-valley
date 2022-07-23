using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    // 재화량
    public int crystalCnt; // 기본 재화 설정
    public int amethystCnt;

    // 재화 증가량
    public int crystalAddByLevel;

    // 백그라운드 재화 획득
    public int intervalAddByLevel;

    // 메인에 배치 가능 개수
    public int mainCnt;

    // 메인에 있는 수룡이 개수
    public int itemCntInMain; // 기본 15개 최대 30개, 5씩 증가

    // 메인에 배치된 수룡이 목록
    public int[] mains;

    // 인벤토리 개수
    public int inventoryCnt; // 기본 12개 최대 36개

    // 인벤토리 목록
    public int[] slots;

    // 인벤토리에 있는 아이템 개수
    public int itemCntInInventory;

    // 사용자
    public int userLevel; // 1부터 시작
    public int userExp; // 0부터 시작
    public double maxUserExp; // 경험치 30, 레벨업 시 경험치*1.5

    // 구매 가능한 수룡이
    public int canBuy; // 0~51

    // 수룡이 친밀도
    public int[] heart;

    // 마지막 접속 시간
    public string EndDate;

    // 음식 개수
    public int foodCnt;
}
