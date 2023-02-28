using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TwinsCordRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField] Transform waterTwin;
    [SerializeField] Transform fireTwin;

    [SerializeField] Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            lineRenderer.SetPositions(new Vector3[] { fireTwin.transform.position + offset, waterTwin.transform.position + offset });
        }
        catch (MissingReferenceException)
        {
            Destroy(lineRenderer);
            Destroy(this);
        }
        
    }
}
