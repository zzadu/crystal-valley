using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrystalAdd : MonoBehaviour
{
    public Text price;
    public GameObject NoSlot;
    public GameObject AddCrystal;

    private void OnEnable()
    {
        DataController.Instance.LoadGameData();
        price.text = DataController.Instance.gameData.AddCrystalPrice.ToString();
    }

    public void buyAddCrystal()
    {
        DataController.Instance.LoadGameData();
        int crystalAddByLevel = DataController.Instance.gameData.crystalAddByLevel;
        crystalAddByLevel += 10;

        price.text = (Int32.Parse(price.text) * 1.5).ToString();
        DataController.Instance.gameData.AddCrystalPrice = Int32.Parse(price.text);

        DataController.Instance.gameData.crystalAddByLevel = crystalAddByLevel;
        DataController.Instance.SaveGameData();

        StartCoroutine(IShowAlert(NoSlot, AddCrystal));
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
