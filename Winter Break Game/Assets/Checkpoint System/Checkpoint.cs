using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    bool collected = false; 
    [SerializeField] EventSystem checkPointEventSystem;
    [SerializeField] CheckPointData data;
    [SerializeField] ParticleSystem collectParticles; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return; 

        if (collision.gameObject.CompareTag("Player"))
        {
            checkPointEventSystem.InvokeEvent("On Checkpoint Collected", new EventData(new EventInfo("Checkpoint", this.gameObject)));
            data.SetCurrentCheckpoint(this.gameObject);

            Debug.Log("Checkpoint Collected");
            if (collectParticles is not null) collectParticles.Emit(50);

            collected = true; 
        }
    }
}
