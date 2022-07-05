using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowCharacter : MonoBehaviour
{
    public GameObject suryongUI;
    public GameObject suryongCanvas;
    GameObject UIInstance;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Start()
    {
        UIInstance = Instantiate(suryongUI, gameObject.transform.position + new Vector3(0, 3f, 0), transform.rotation) as GameObject;
        UIInstance.transform.SetParent(suryongCanvas.transform);
        UIInstance.transform.GetChild(0).GetComponentInChildren<Text>().text = gameObject.name;
        UIInstance.SetActive(false);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        if (gameObject.transform.position.y < 4f)
            UIInstance.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0, 2f, 0));
        else
            UIInstance.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0, -2f, 0));

    }

    private void OnMouseDown()
    {
        print("click!");
        UIInstance.SetActive(true);
    }
}
