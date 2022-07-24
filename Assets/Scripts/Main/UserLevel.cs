using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLevel : MonoBehaviour
{
    [SerializeField] Text userLevelTxt;
    static Text levelTxt;
    [SerializeField] Slider userExpSilder;
    static Slider expSlider;

    static int userExp;
    static double maxUserExp;
    static int userLevel;

    [SerializeField] Image levelupPopup;
    static Image levelup;

    const int maxUserLevel = 20;

    void Start()
    {
        DataController.Instance.LoadGameData();
        levelTxt = userLevelTxt;
        levelTxt.text = DataController.Instance.gameData.userLevel.ToString();
        expSlider = userExpSilder;
        expSlider.value = (float)(DataController.Instance.gameData.userExp / DataController.Instance.gameData.maxUserExp);
        levelup = levelupPopup;
    }

    public static void updateExp()
    {
        userExp = DataController.Instance.gameData.userExp;
        maxUserExp = DataController.Instance.gameData.maxUserExp;
        userLevel = DataController.Instance.gameData.userLevel;

        expSlider.value = (float)(userExp / maxUserExp);

        if (userExp >= maxUserExp && userLevel < maxUserLevel)
        {
            userExp -= (int)maxUserExp;
            maxUserExp = (maxUserExp * 1.5);

            levelup.gameObject.SetActive(true);
            StaticCoroutine.DoCoroutine(ILevelupPopup());

            DataController.Instance.gameData.userLevel = userLevel;
            DataController.Instance.gameData.userExp = userExp;
            DataController.Instance.gameData.maxUserExp = maxUserExp;
            DataController.Instance.SaveGameData();
        }
    }

    static IEnumerator ILevelupPopup()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            levelup.rectTransform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }

        yield return new WaitForSeconds(2f);
        levelTxt.text = (++userLevel).ToString();
        expSlider.value = 0;
        levelup.rectTransform.localScale = new Vector3(1f, 1f, 1f);

        levelup.gameObject.SetActive(false);

        DataController.Instance.gameData.userLevel = userLevel;
        DataController.Instance.SaveGameData();
    }

    public static void FeedExp()
    {
        DataController.Instance.LoadGameData();
        userExp = DataController.Instance.gameData.userExp;

        userExp += 5;

        DataController.Instance.gameData.userExp = userExp;
        DataController.Instance.SaveGameData();
        updateExp();
    }
}