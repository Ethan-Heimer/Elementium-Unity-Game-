using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLogicCullingToObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        foreach(var o in GetComponentsInChildren<Transform>())
        {
            if (o.gameObject == gameObject) continue;
            o.gameObject.AddComponent<DisableLogicWhenHidden>();
        }
    }

    public void Update()
    {
        
    }
}
