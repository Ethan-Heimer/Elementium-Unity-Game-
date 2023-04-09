using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterGroundStatusInterfacer : CharacterComponentInterfacer<GroundStatusProvider>
{
    

    public CharacterGroundStatusInterfacer(Character _character, CharacterConfigManager config) : base(_character, config) { }

    public void Tick()
    {
        if (character.enviormentStatuses.GetStatus("Climb")) return;

    }

    public void DrawGizmos() => Component.DrawGizmos(character);
}
