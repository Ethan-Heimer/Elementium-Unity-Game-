using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltObject : RayAffectable
{
    [SerializeField] EventSystem interactibleEventSystem; 
    SpriteRenderer renderer;

    [Header("Settings")]
    [SerializeField] float timeToMelt;
    [SerializeField] ParticleSystem meltParticles;

    [SerializeField] bool glowWhileMelting; 

    float elapsedTime;
    float percentComplete; 

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        meltParticles.Stop(); 
    }

  
    public override void OnHit(Vector2 intercention)
    {
        elapsedTime += Time.deltaTime;
        percentComplete = elapsedTime / timeToMelt;

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.g, (1-percentComplete));

        if(glowWhileMelting)
        renderer.material.SetColor("_Glow", new Color(30*percentComplete + 1, 1, 1));

        if(renderer.color.a <= 0)
        {
            Destroy(gameObject);
            interactibleEventSystem.InvokeEvent("On Destroy", new EventData(new EventInfo("GameObject", gameObject))); 
        }

        if (meltParticles is null) return; 
        if (!meltParticles.isPlaying) meltParticles.Play(); 
    }
}
