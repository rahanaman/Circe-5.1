using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectOnBattleData
{
    protected int stack;
    public EffectOnBattleData(EffectID id)
    {
        ID = id;
    }
    public EffectOnBattleData(EffectID id, int[] data)
    {
        ID = id;
        stack = data[0];
    }
    public EffectID ID { get; private set; }
    public int[] Data
    {
        get
        {
            return new int[] { stack };
        }

        set
        {
            stack = value[0];
        }

    }
}
public abstract class EffectBase
{
    public EffectID ID { get; protected set; }
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents { get; protected set; }
    public string Desc { get; protected set; }
    
}


public class 경감Effect : EffectBase
{
   public 경감Effect()
    {
        ID = EffectID.경감;
        Desc = "입는 공격 피해를 {1}만큼 감소시킵니다.";

    }
}