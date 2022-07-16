using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    int itemCntInMain;
    int[] mains;

    public void RemoveSuryong()
    {
        DataController.Instance.LoadGameData();
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;
        mains = DataController.Instance.gameData.mains;

        itemCntInMain--;

        int remove = 0;
        for (int i = 0; i < mains.Length - 1; i++)
        {
            if (mains[i] == UIFollowCharacter.select)
                remove = i;
        }

        for (int i = remove; i < mains.Length - 1; i++)
        {
            mains[i] = mains[i + 1];
        }

        DataController.Instance.gameData.itemCntInMain = itemCntInMain;
        DataController.Instance.gameData.mains = mains;
        DataController.Instance.SaveGameData();

        Destroy(UIFollowCharacter.selection);
        Destroy(gameObject);
    }
}
