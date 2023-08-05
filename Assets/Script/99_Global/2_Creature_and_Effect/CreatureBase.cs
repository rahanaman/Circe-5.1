using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.UIElements;
using UnityEngine;

public abstract class CreatureOnBattleData
{
    public int MaxHP { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int Defence { get; protected set; }
    public EffectID Effects { get; protected set; }
    public DataCalc[] GetDataCalcs { get; protected set; }
    public DataCalc[] GiveDataCalcs { get; protected set; }

    public abstract CreatureBase GetCreatureBase();

    public abstract void Init();
 
    public void ExecuteGetAction(BattleDataID id, int data)
    {
        int calcData = GetDataCalcs[(int)id].Data(data);
        switch (id)
        {
            case BattleDataID.Dmg:
                GetDamage(calcData);
                break;
        }
    }

    protected void GetDamage(int damage) //WIP
    {
        if (IsDefAvail())
        {

        }
        else
        {
            CurrentHP -= damage;
        }
    }

    protected bool IsDefAvail()
    {
        return Defence > 0;
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
