using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject showButton;
    public GameObject scrollView;

    public void showScroll()
    {
        scrollView.SetActive(true);
        gameObject.SetActive(false);
    }

    public void showButtons()
    {
        showButton.SetActive(true);
    }

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
