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
        //업데이트시마다 자수정, 크리스탈값 받아와 string으로 전환
        string stringCrystal = DataController.Instance.gameData.crystalCnt.ToString();
        CrystalTxt.text = stringCrystal;
        string stringAmethyst = DataController.Instance.gameData.amethystCnt.ToString();
        AmethystTxt.text = stringAmethyst;
        
    }
}
