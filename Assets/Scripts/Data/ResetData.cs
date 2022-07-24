using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResetData : MonoBehaviour
{
    private void Awake()
    {
        DataController.Instance.LoadGameData();
        // ResetDatas();

        // 경험치
        if (DataController.Instance.gameData.userLevel == 0)
            DataController.Instance.gameData.userLevel = 1;

        if (DataController.Instance.gameData.maxUserExp == 0)
            DataController.Instance.gameData.maxUserExp = 30;

        // 홈 아이템 목록
        if (DataController.Instance.gameData.mains.Length == 0)
        {
            DataController.Instance.gameData.mains = new int[40];
        }

        // 인벤토리 아이템 목록
        if (DataController.Instance.gameData.slots.Length == 0)
        {
            DataController.Instance.gameData.slots = new int[36];
        }

        // 메인 배치 가능 수
        if (DataController.Instance.gameData.mainCnt == 0)
        {
            DataController.Instance.gameData.mainCnt = 10;
        }
        
        // 친밀도
        if (DataController.Instance.gameData.heart.Length == 0)
        {
            DataController.Instance.gameData.heart = new int[52];
            DataController.Instance.gameData.heart = Enumerable.Repeat<int>(0, 52).ToArray<int>();
        }

        // 시간에 따른 증가량
        if (DataController.Instance.gameData.intervalAddByLevel == 0)
            DataController.Instance.gameData.intervalAddByLevel = 1;

        // 탭 시 증가량
        if (DataController.Instance.gameData.crystalAddByLevel == 0)
            DataController.Instance.gameData.crystalAddByLevel = 10;

        if (DataController.Instance.gameData.AddCrystalPrice == 0)
            DataController.Instance.gameData.AddCrystalPrice = 100;
    }

    public static void ResetDatas()
    {
#if (UNITY_EDITOR)
        DataController.Instance.gameData.crystalCnt = 10000;
#else
        DataController.Instance.gameData.crystalCnt = 0;
#endif


        DataController.Instance.gameData.itemCntInMain = 0;
        DataController.Instance.gameData.mains = new int[40];
        DataController.Instance.gameData.slots = new int[36];
        DataController.Instance.gameData.itemCntInInventory = 0;
        DataController.Instance.gameData.heart = new int[52];
        DataController.Instance.gameData.heart = Enumerable.Repeat<int>(0, 52).ToArray<int>();
        DataController.Instance.gameData.userLevel = 1;
        DataController.Instance.gameData.maxUserExp = 30;
        DataController.Instance.gameData.userExp = 0;
        DataController.Instance.gameData.crystalAddByLevel = 0;
        DataController.Instance.gameData.intervalAddByLevel = 0;
        DataController.Instance.gameData.inventoryCnt = 12;

        DataController.Instance.SaveGameData();
    }
}
