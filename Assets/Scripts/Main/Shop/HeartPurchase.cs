using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPurchase : MonoBehaviour
{
    int[] heart; // 친밀도
    int canBuy; // 구매 가능한 수룡이
  

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); // 게임이 시작되었을 때 보이지 않도록
        
    }

    public bool heart_check() // 사용자가 구매한 수룡이들의 호감도가 일정 값 이상인지 체크
    {
        int count = 0;
        int userHave = canBuy - 1; // 현재 사용자가 소유한 수룡이 = 구매가능한 수룡이 -1 번호

        while(count == userHave)
        {
            if (heart[count] < 90) // 친밀도 90 미만이면 false 반환
            {
                return false;
            }
        }
        return true;
    }

    public void heart_purchase(int item)
    {
        if (heart_check()) // heart_check 결과가 true면
            canBuy += 1; // 구매 가능한 수룡이 숫자 증가
    }
  
}
