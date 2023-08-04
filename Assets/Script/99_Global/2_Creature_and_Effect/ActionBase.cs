using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase // Battle���� �̷���� �� �ִ� ��� �ൿ 
{
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents;
    public abstract void Action(params CreatureOnBattleData[] targets); //BattlePanelManager���� ������ OnBattleData���� ������ �̷����
}

public class ����Action : ActionBase
{
    public ����Action() { }
    public ����Action(int damage)
    {
        Damage = damage;
    }
    
    public int Damage { get; private set; }

    public override void Action(params CreatureOnBattleData[] targets)
    {
        foreach (var target in targets)
        {
            
        }
    }
}
