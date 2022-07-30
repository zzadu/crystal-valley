using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Active();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("InActive", 10f);
        Invoke("Active", 10f);
        while (Active())
        {
            this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
        }
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
