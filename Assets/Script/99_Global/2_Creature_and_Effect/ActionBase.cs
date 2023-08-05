using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase // Battle에서 이루어질 수 있는 모든 행동 
{
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents;
    public abstract void Action(params CreatureOnBattleData[] targets); //BattlePanelManager에서 가져온 OnBattleData에서 수정이 이루어짐
}

public class 공격Action : ActionBase
{
    public 공격Action() { }
    public 공격Action(int damage)
    {
        Damage = damage;

    }
    
    public int Damage { get; private set; }

    public override void Action(params CreatureOnBattleData[] targets)
    {
        int calcData = BattleManager.Instance.GetOnProgressDataCalcs()[(int)BattleDataID.Dmg].Data(Damage);
        foreach (var target in targets)
        {
            target.ExecuteGetAction(BattleDataID.Dmg, calcData);
        }
    }
}

public class 힘Action : ActionBase
{
    public 힘Action()
    {

    }

    public override void Action(params CreatureOnBattleData[] targets)
    {
        
    }
}
