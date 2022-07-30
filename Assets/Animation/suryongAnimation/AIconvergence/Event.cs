using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        InActive();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Active", 10f);
        Invoke("InActive", 10f);
    }

    bool Active()
    {
        gameObject.SetActive(true);
        return true;
    }
    void InActive()
    {
        gameObject.SetActive(false);
    }
}
