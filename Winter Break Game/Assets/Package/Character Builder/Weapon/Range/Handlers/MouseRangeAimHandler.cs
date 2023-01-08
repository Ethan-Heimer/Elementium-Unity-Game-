using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRangeAimHandler : MonoBehaviour, IAimHandler
{
    public float GetAimAngle()
    {
        Vector3 lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        return (180 / Mathf.PI) * AngleRad;
    }
}
