using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Heart : MonoBehaviour
{
    int[] heart;
    int foodCnt;

    private void Awake()
    {
        
        // 친밀도
        if (DataController.Instance.gameData.heart.Length == 0)
        {
            DataController.Instance.gameData.heart = new int[52];
            DataController.Instance.gameData.heart = Enumerable.Repeat<int>(0, 52).ToArray<int>();
            DataController.Instance.SaveGameData();
        }
        heart = DataController.Instance.gameData.heart;
        

        // 음식 개수
        foodCnt = DataController.Instance.gameData.foodCnt;
    }

    public void Feed()
    {
        if (foodCnt > 0)
        {
            heart[UIFollowCharacter.select - 1] += 5;
            DataController.Instance.gameData.heart = heart;
            foodCnt--;
            DataController.Instance.gameData.foodCnt = foodCnt;
            DataController.Instance.SaveGameData();
        }
        else
        {
            StartCoroutine(IShowAlert(gameObject.transform.parent.GetChild(0).gameObject, gameObject.transform.parent.GetChild(0).GetChild(1).gameObject));
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
