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
    //    this.gameObject.SetActive(false); // ������ ���۵Ǿ��� �� ������ �ʵ���
        
    //}

    public GameObject Button;
  
    public void Update()
    {
        DataController.Instance.LoadGameData();

        
        Button.GetComponent<Button>().interactable = false; // ��ư ��Ȱ��ȭ

        if (DataController.Instance.gameData.heart[Int32.Parse(gameObject.name) - 2] >= 70) // ���� ������ ȣ���� 70 �̻��� ��
        {
            Button.GetComponent<Button>().interactable = true; // ��ư Ȱ��ȭ
        }


    }
}
