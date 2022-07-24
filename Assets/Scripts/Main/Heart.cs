using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    int[] heart;
    public Sprite[] foods;

    public Image foodImage;
    public Text foodPrice;

    public Text heartTxt;

    private void OnEnable()
    {

        // 친밀도
        if (DataController.Instance.gameData.heart.Length == 0)
        {
            DataController.Instance.gameData.heart = new int[52];
            DataController.Instance.gameData.heart = Enumerable.Repeat<int>(0, 52).ToArray<int>();
            DataController.Instance.SaveGameData();
        }
        heart = DataController.Instance.gameData.heart;


        // 음식 가격, 사진
        int select = UIFollowCharacter.select;
        if (select < 8)
        {
            foodPrice.text = "1000";
            foodImage.sprite = foods[0];
        }
        else if (select < 15)
        {
            foodPrice.text = "2000";
            foodImage.sprite = foods[1];
        }
        else if (select < 22)
        {
            foodPrice.text = "3000";
            foodImage.sprite = foods[2];
        }
        else if (select < 29)
        {
            foodPrice.text = "4000";
            foodImage.sprite = foods[3];
        }
        else if (select < 36)
        {
            foodPrice.text = "5000";
            foodImage.sprite = foods[4];
        }
        else if (select < 43)
        {
            foodPrice.text = "6000";
            foodImage.sprite = foods[5];
        }
        else
        {
            foodPrice.text = "7000";
            foodImage.sprite = foods[7];
        }
    }

    public void Feed()
    {
        DataController.Instance.LoadGameData();
        int crystal = DataController.Instance.gameData.crystalCnt;
        int price = Int32.Parse(foodPrice.text);

        if (crystal >= price)
        {
            heart[UIFollowCharacter.select - 1] += 5; // 친밀도 증가
            crystal -= price;

            DataController.Instance.gameData.crystalCnt = crystal;
            DataController.Instance.gameData.heart = heart;

            heartTxt.text = heart[UIFollowCharacter.select - 1].ToString();

            UserLevel.FeedExp(); // 경험치 증가
            DataController.Instance.SaveGameData();
        }
        else
        {
            StartCoroutine(IShowAlert(gameObject.transform.parent.GetChild(0).gameObject, gameObject.transform.parent.GetChild(0).GetChild(5).gameObject));
        }
    }

    IEnumerator IShowAlert(GameObject obj1, GameObject obj2)
    {
        obj1.SetActive(true);
        obj2.SetActive(true);
        yield return new WaitForSeconds(2f);
        obj1.SetActive(false);
        obj2.SetActive(false);
    }
}
