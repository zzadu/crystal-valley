using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartPurchase : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    this.gameObject.SetActive(false); // 게임이 시작되었을 때 보이지 않도록
        
    //}

    public GameObject Button;
  
    public void Update()
    {
        DataController.Instance.LoadGameData();

        
        Button.GetComponent<Button>().interactable = false; // 버튼 비활성화

        if (DataController.Instance.gameData.heart[Int32.Parse(gameObject.name) - 2] >= 70) // 이전 아이템 호감도 70 이상일 때
        {
            Button.GetComponent<Button>().interactable = true; // 버튼 활성화
        }


    }
}
