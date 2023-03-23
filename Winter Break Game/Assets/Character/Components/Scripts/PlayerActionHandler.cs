using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Action Handler", menuName = "Character Components/Action Handlers/Player Action Handler")]
public class PlayerActionHandler : CharacterActionHandler
{
    ElementRay ray;

    public override void OnStart(Character character)
    {
        ray = character.GetComponentInChildren<ElementRay>();
        Debug.Log("Invoked");
    }

    public override void OnAction(Character character)
    {
        ray.FireRay();
    }
}
