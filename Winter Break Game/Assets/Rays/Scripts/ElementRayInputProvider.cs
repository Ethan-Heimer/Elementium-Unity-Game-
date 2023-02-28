using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayInputProvider : MonoBehaviour, IElementRayInputProvider
{
    [SerializeField] bool UseContoller; 
    Camera cam;
    private void Awake()
    {
        cam = Camera.main; 
    }
   

    public Vector3 GetAimVector()
    {
        if(Input.GetJoystickNames().Length > 0 && UseContoller)
        {
            Vector2 aim = new Vector3(Input.GetAxis("AimY"), -Input.GetAxis("AimX"));
            return aim; 
        }
        else
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);

            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
}
