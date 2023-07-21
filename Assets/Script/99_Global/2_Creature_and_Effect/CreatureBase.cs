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
    //�� ũ��ó�� ������ �ִ� ���� ��� �ڵ��ϴ� Ŭ����

    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents;
}
