using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ReflectionTester : MonoBehaviour
{
    // Start is called before the first frame update
    public float Text1 = 10;
    public float Test2 = 20;
    public float Test3 = 30;

    void Start()
    {
        FieldInfo[] infos = typeof(ReflectionTester).GetFields();

        foreach(FieldInfo o in infos)
        {
            Debug.Log(o.GetValue(this));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
