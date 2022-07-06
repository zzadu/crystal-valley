using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowCharacter : MonoBehaviour
{
    public GameObject suryongUI;
    public GameObject suryongCanvas;
    GameObject UIInstance;

    public static GameObject selection;
    public static int select = 0;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Start()
    {
        // ÆË¾÷ UI ÀÎ½ºÅÏ½ºÈ­
        UIInstance = Instantiate(suryongUI, gameObject.transform.position + new Vector3(0, 3f, 0), transform.rotation) as GameObject;
        UIInstance.transform.SetParent(suryongCanvas.transform);
        UIInstance.transform.GetChild(0).GetComponentInChildren<Text>().text = gameObject.name;
        UIInstance.SetActive(false);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        // ÆË¾÷Ã¢ ¼ö·æÀÌ µû¶ó´Ù´Ô
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
        print(selection.name);
        select = int.Parse(selection.name);
    }

}
