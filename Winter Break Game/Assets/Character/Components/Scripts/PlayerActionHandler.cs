using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

[CreateAssetMenu(fileName = "New Action Handler", menuName = "Character Components/Action Handlers/Player Action Handler")]
public class PlayerActionHandler : CharacterActionHandler
{
    public event Action<Character> Test;
    ElementRay ray;

    public override void OnStart(Character character)
    {
        ray = character.GetComponentInChildren<ElementRay>();
        //Debug.Log(this.GetType().GetEvent("Test").EventHandlerType == typeof(Action<Character>));
    }

    public override void OnAction(Character character)
    {
        Test?.Invoke(character);
        ray.FireRay();
    }
}
