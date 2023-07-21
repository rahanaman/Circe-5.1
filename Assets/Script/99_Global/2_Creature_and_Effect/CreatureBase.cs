using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public abstract class CreatureOnBattleData
{
    public int MaxHP { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int Defence { get; protected set; }
    public EffectID Effects { get; protected set; }

    public abstract CreatureBase GetCreatureBase();

    public void GetDamage()
    {

    }

    public void ResetDefence()
    {

    }
}




public abstract class CreatureBase 
{
    //각 크리처가 가지고 있는 고유 기믹 코딩하는 클래스

    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents;
}
