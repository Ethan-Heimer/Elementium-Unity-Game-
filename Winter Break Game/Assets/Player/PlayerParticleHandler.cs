using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleHandler : MonoBehaviour
{
    ICharacterEventHandler eventHandler;

    [SerializeReference][Tooltip("Use Context Menu to Add Events")] List<ParticleEvent> particleEvents = new List<ParticleEvent>(); 
    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GetComponent<Character>().config.eventHandler;

        foreach (ParticleEvent o in particleEvents)
        {
            eventHandler.SubscribeToEvent(o.eventName, o.OnInvoke); 
        }
    }

    private void OnDisable()
    {
        foreach (ParticleEvent o in particleEvents)
        {
            eventHandler.UnsubscribeToEvent(o.eventName, o.OnInvoke);
        }
    }

    [ContextMenu("Add Play Event")] void AddPlayEvent() => particleEvents.Add(new PlayParticles());
    [ContextMenu("Add Emit Event")] void AddEmitEvent() => particleEvents.Add(new EmitParticles());
}

[System.Serializable]
internal abstract class ParticleEvent
{

    public string eventName;
    public ParticleSystem particles; 
    public abstract void OnInvoke(); 
}

internal class PlayParticles : ParticleEvent
{
    public bool Play; 
    public override void OnInvoke()
    {
        if (Play)
        {
            particles.Play();
        }
        else
        {
            particles.Stop();
        }
    }
}
internal class EmitParticles : ParticleEvent
{
    public int emitAmount = 0; 
    public override void OnInvoke() => particles.Emit(emitAmount);
}
