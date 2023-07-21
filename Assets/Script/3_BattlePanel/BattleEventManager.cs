using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void TriggeredAction(CreatureOnBattleData creature);
public class BattleEventManager
{
    public TriggeredAction[] TriggeredActions;

    public void InitEvent()
    {
        TriggeredActions = new TriggeredAction[Enum.GetValues(typeof(TriggerID)).Length];
    }    
}
