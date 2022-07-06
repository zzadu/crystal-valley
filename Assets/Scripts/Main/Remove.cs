using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public void RemoveSuryong()
    {
        Destroy(UIFollowCharacter.selection);
        Destroy(gameObject);
    }
}
