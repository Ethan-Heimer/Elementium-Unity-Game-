using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridLock : MonoBehaviour
{
    public int LockBy;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x * LockBy) / LockBy, Mathf.Round(transform.position.y * LockBy) / LockBy, transform.position.z); 
    }
}
