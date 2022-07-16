using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{

    public GameObject[] suryongPrefab;
    public GameObject range;
    BoxCollider2D collider;

    int itemCntInMain;
    int[] mains;

    private void Start()
    {
        // ���� �ʱ�ȭ
        // DataController.Instance.gameData.mains = new int[40];
        // DataController.Instance.gameData.itemCntInMain = 0;

        DataController.Instance.LoadGameData();
        // Ȩ ������ ����
        itemCntInMain = DataController.Instance.gameData.itemCntInMain;

        // Ȩ ������ ���
        mains = DataController.Instance.gameData.mains;

        // ���� ���� ����
        collider = range.GetComponent<BoxCollider2D>();

        // ������ ��ġ ���� ����
        for (int i = 0; i < itemCntInMain; i++)
        {
            print(mains[i]);
            GameObject prefab = Instantiate(suryongPrefab[mains[i] - 1]);
            Vector3 pos = range.transform.position;
            float x = collider.bounds.size.x;
            float y = collider.bounds.size.y;

            x = Random.Range(-x / 2, x / 2);
            y = Random.Range(-y / 2, y / 2);
            Vector3 randomPos = new Vector3(x, y);

            Vector3 spawnPos = pos + randomPos;
            spawnPos.z = -2;
            prefab.transform.position = spawnPos;
            prefab.gameObject.name = mains[i].ToString();
        }
    }
}
