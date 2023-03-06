using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour
{
    [SerializeField] float lifeTime;
    Timer timer; 
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(lifeTime);
        timer.ResetTimer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer.IsTimerUp()) Destroy(gameObject);
    }
}
