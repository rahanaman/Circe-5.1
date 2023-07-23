using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public delegate void TriggeredAction();

public class BattleEventManager
{
    public Dictionary<CreatureOnBattleData, TriggeredAction[]> TriggeredActions;


    public void Init()
    {
        TriggeredActions = new Dictionary<CreatureOnBattleData, TriggeredAction[]>();
        
    }
    public void AddTriggerDict(CreatureOnBattleData creature)
    {
        TriggeredActions.Add(creature, new TriggeredAction[Enum.GetValues(typeof(TriggerID)).Length]);
    }

    public void InvokeTrigger(TriggerID id, CreatureOnBattleData creature)
    {
        TriggeredActions[creature][(int)id]?.Invoke();
    }



}
