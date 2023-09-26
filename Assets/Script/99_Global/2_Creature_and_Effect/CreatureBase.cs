using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.UIElements;
using UnityEngine;


public abstract class OnBattleData
{
    public int MaxHP { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int Defence { get; protected set; }

    public EffectOnBattleData[] Effects { get; protected set; }
    public DataCalc[] GetDataCalcs { get; protected set; }
    public DataCalc[] GiveDataCalcs { get; protected set; }
    public abstract CreatureBase GetCreatureBase();

    public TriggeredAction Trigger;

    

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

    protected bool IsDefAvail() => Defence > 0;

    public void ResetDefence()
    {

    }

    public abstract void CallOnTurnBegin();
    public abstract void CallOnTurnEnd();
}


public abstract class CreatureOnBattleData<T> : OnBattleData
{
    public abstract void Init(T id);
}




public abstract class CreatureBase 
{
   
}
