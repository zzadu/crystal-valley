using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPurchase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); // 게임이 시작되었을 때 보이지 않도록
        
    }

    public bool HeartCheck() // 사용자가 구매한 수룡이들의 호감도가 일정 값 이상인지 체크
    {
        DataController.Instance.LoadGameData();
        int count = 0;
        

        while(count == DataController.Instance.gameData.canBuy - 1) // 현재 사용자가 소유한 수룡이 = 구매가능한 수룡이 -1 번호
        {
            if (DataController.Instance.gameData.heart[count] < 70) // 친밀도 70 미만이면 false 반환
            {
                return false;
            }
            count++;
        }
        return true;
    }

    public void PurchaseByHeart(int item)
    {
        if (HeartCheck()) // HeartCheck 결과가 true면
            DataController.Instance.gameData.canBuy += 1; // 구매 가능한 수룡이 숫자 증가
    }
  
}
