using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Movement Handler", menuName = "Character Components/Movement Handlers/Empty Movement Handler")]
public class EmptyMovementHandler : CharacterMovementHandler
{
    // Start is called before the first frame update
    public override void OnStart(Character character)
    {
        
    }

    // Update is called once per frame
    public override void OnUpdate(Character character)
    {
        
    }

    public override void OnFixedUpdate(Character character)
    {

    }
}
