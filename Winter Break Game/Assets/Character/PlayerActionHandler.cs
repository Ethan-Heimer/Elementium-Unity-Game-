using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionHandler : CharacterClass, ICharacterActionHandler
{
    ElementRay ray; 
    public void Start()
    {
        ray = character.GetComponentInChildren<ElementRay>(); 
    }

    public void OnAction()
    {
       ray.FireRay();
        
    }
}
