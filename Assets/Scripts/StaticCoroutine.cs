using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCoroutine : MonoBehaviour
{
    private static StaticCoroutine Instance = null;

    private static StaticCoroutine instance {
        get
        {
            if (Instance == null)
            {
                Instance = GameObject.FindObjectOfType(typeof(StaticCoroutine)) as StaticCoroutine;
                if (Instance == null)
                {
                    Instance = new GameObject("StaticCoroutine").AddComponent<StaticCoroutine>();
                }
            }
            return Instance;
         }
     }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as StaticCoroutine;
        }
    }

    IEnumerator Perform(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine);
        Die();
    }

    public static void DoCoroutine(IEnumerator coroutine)
    {
        instance.StartCoroutine(instance.Perform(coroutine));
    }

    void Die()
    {
        Instance = null;
        Destroy(gameObject);
    }

    private void OnApplicationQuit()
    {
        Instance = null;
    }
}
