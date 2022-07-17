using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Text CrystalTxt;
    [SerializeField] private Text AmethystTxt;

    
    void Update()
    {
        //������Ʈ�ø��� �ڼ���, ũ����Ż�� �޾ƿ� string���� ��ȯ
        string stringCrystal = DataController.Instance.gameData.crystalCnt.ToString();
        CrystalTxt.text = stringCrystal;
        string stringAmethyst = DataController.Instance.gameData.amethystCnt.ToString();
        AmethystTxt.text = stringAmethyst;
        
    }
}
