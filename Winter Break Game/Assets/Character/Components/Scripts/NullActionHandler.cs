using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action Handler", menuName = "Character Components/Action Handlers/Empty Action Handler")]
public class NullActionHandler : CharacterActionHandler
{
    // Update is called once per frame
    public override void OnAction(Character character)
    {
        
    }
}
