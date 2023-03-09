using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using System; 

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    public static event Action<GameObject> OnCheckPointCollected;
    [SerializeField] UnityEvent OnCollected;

    bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return; 

        if (collision.gameObject == Character.GetPlayer().gameObject)
        {
            OnCheckPointCollected?.Invoke(this.gameObject);
            OnCollected?.Invoke();

            collected = true; 
        }
    }
}
