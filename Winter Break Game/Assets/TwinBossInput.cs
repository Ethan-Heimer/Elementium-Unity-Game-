using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBossInput : SlimeInputHandler
{
    Timer actionTime;
    public override void Constructer(Character _character)
    {
        base.Constructer(_character);
        actionTime = new Timer(character.statsHandler.GetStat("Action Time"));
        actionTime.ResetTimer();
    }

    public override bool GetActionInput()
    {
        bool t = actionTime.IsTimerUp();

        if(t)
            actionTime.ResetTimer(character.statsHandler.GetStat("Action Time"));
        
        return t; 
    }
}
