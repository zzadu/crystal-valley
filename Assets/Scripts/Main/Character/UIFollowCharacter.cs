using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowCharacter : MonoBehaviour
{
    public GameObject suryongUI;
    GameObject suryongCanvas;
    GameObject UIInstance;

    public static GameObject selection;
    public static int select = 0;

    private void Awake()
    {
        suryongCanvas = GameObject.Find("SuryongCanvas");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // ģ�е�
        if (DataController.Instance.gameData.heart.Length == 0)
        {
            DataController.Instance.gameData.heart = new int[52];
            DataController.Instance.gameData.heart = Enumerable.Repeat<int>(0, 52).ToArray<int>();
            DataController.Instance.SaveGameData();
        }
    }

    private void Start()
    {
        // �˾� UI �ν��Ͻ�ȭ
        UIInstance = Instantiate(suryongUI, gameObject.transform.position + new Vector3(0, 3f, 0), transform.rotation) as GameObject;
        UIInstance.transform.SetParent(suryongCanvas.transform);
        UIInstance.transform.GetChild(0).GetComponentInChildren<Text>().text = gameObject.name;
        UIInstance.SetActive(false);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        // ģ�е� ǥ��
        UIInstance.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = DataController.Instance.gameData.heart[int.Parse(gameObject.name) - 1].ToString();

        // ���� ���� ǥ��
        UIInstance.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = DataController.Instance.gameData.foodCnt.ToString();
    }

    void Update()
    {
        // �˾�â ������ ����ٴ�
        if (gameObject.transform.position.y < 4f)
            UIInstance.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0, 2f, 0));
        else
            UIInstance.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0, -2f, 0));

    }

    private void OnMouseDown()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);

        selection = hit.collider.gameObject;

        print("click!");
        UIInstance.SetActive(true);
        select = int.Parse(selection.transform.gameObject.name);
    }

}
