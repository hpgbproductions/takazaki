using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttachSideObjectProximityLoaders : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            obj.AddComponent<SideObjectProximityLoader>();
        }
    }
}
