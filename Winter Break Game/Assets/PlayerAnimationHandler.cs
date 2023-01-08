using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;
    ICharacterEventHandler eventHandler; 

    [System.Serializable]
    struct AnimationEvent
    {
        public string eventName;
        public string animationName; 
    }

    [SerializeField] AnimationEvent[] animationEvents; 
    void Start()
    {
        animator = GetComponent<Animator>();
        eventHandler = GetComponent<ICharacterEventHandler>();

        foreach (AnimationEvent o in animationEvents)
        {
            eventHandler.SubscribeToEvent(o.eventName, () => animator.Play(o.animationName)); 
        }
    }

    private void OnDisable()
    {
        foreach (AnimationEvent o in animationEvents)
        {
            eventHandler.UnsubscribeToEvent(o.eventName, () => animator.Play(o.animationName));
        }
    }
}
