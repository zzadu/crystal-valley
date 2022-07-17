using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userUI : MonoBehaviour
{
    [SerializeField] private Text levelTxt;
    [SerializeField] private Text expTxt;
    void Update()
    {
        string strUserLevel = DataController.Instance.gameData.userLevel.ToString();
        levelTxt.text = strUserLevel;
        string strUserExp = DataController.Instance.gameData.userExp.ToString();
        expTxt.text = strUserExp;
        
    }
}
