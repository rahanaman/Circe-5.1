using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public delegate void TriggeredAction();

public class BattleEventManager
{
    public Dictionary<OnBattleData, TriggeredAction[]> TriggeredActions;


    public void Init()
    {
        TriggeredActions = new Dictionary<OnBattleData, TriggeredAction[]>();
        
    }
    public void AddTriggerDict(OnBattleData creature)
    {
        TriggeredActions.Add(creature, new TriggeredAction[Enum.GetValues(typeof(TriggerID)).Length]);
    }

    public void InvokeTrigger(TriggerID id, OnBattleData creature)
    {
        TriggeredActions[creature][(int)id]?.Invoke();
    }



}
