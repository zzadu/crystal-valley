using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    int crystalCnt;
    public Text crystalDisplay;

    void Start()
    {
        crystalCnt = DataController.Instance.gameData.crystalCnt;
    }

    void Update()
    {
        // DataController.Instance.LoadGameData();
        crystalCnt = DataController.Instance.gameData.crystalCnt;
        crystalDisplay.text = crystalCnt.ToString();
    }
}
