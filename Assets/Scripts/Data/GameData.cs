using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    // 재화량
    public int crystalCnt = 0; // 기본 재화 설정
    public int amethystCnt = 0;

    // 메인 배치 가능 개수
    public int canPlace; // 기본 15개

    // 메인에 배치된 수룡이 목록

    // 인벤토리 개수
    public int inventoryCnt; // 기본 20개
    
    // 인벤토리 목록

    // 사용자
    public int userLevel; // 1부터 시작
    public int userExp; // 0부터 시작

    // 구매 가능한 수룡이
    public bool[] canBuy; // {1, 0}, 52개

    // 수룡이 친밀도
    public int[] intimacy;
}
