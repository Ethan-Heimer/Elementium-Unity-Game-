using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] Light2D light;

    [Header("Settings")]
    [SerializeField] float baseIntencity;
    [SerializeField] float flickerIntensity;
    [SerializeField] float flickerSpeed; 

    // Update is called once per frame
    void FixedUpdate()
    {
        light.intensity = GetIntencity(Time.time); 
    }

    float GetIntencity(float x) => (baseIntencity + Mathf.Sin(x * flickerSpeed) * flickerIntensity); 
}
