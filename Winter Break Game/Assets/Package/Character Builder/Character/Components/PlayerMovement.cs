using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IOnCharacterUpdate
{
    public float speed = 3; 
    public void OnCharacterUpdate()
    {
        float xDir = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yDir = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(xDir, yDir, 0);
    }
}
