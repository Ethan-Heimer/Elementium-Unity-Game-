using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField, Range(0.01f, 1f)] float smoothSpeed;

    [SerializeField] Vector3 offset;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        Vector3 desieredPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);

        transform.position = desieredPosition; 
    }
}
