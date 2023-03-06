using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    Camera _camera;

    [SerializeField] float paralaxSpeed;

    [SerializeField]bool freezeY;
    float startY; 
   

    Vector3 pos; 
    private void Awake()
    {
        _camera = Camera.main;

        if (freezeY) startY = transform.position.y; 

    }

    void Start()
    {
       
    }

    void Update()
    {
        int x = Mathf.FloorToInt(_camera.transform.position.x * (float)16);

        pos.x = (float)((float)x/16)/paralaxSpeed;

        if (freezeY) pos.y = startY; 
        else pos.y = transform.position.y;

        transform.position = pos; 
    }
}
