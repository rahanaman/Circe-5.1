using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectOnBattleData
{
    public EffectOnBattleData(EffectID id)
    {
        ID = id;
    }
    public EffectOnBattleData(EffectID id, int[] data)
    {
        ID = id;
        Data = data;
    }
    public EffectID ID { get; private set; }
    public int[] Data { get; private set; }
}
public abstract class EffectBase
{
    public EffectID ID { get; protected set; }
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents { get; protected set; }
    public string Desc { get; protected set; }
    
}


public class �氨Effect : EffectBase
{
   public �氨Effect()
    {
        ID = EffectID.�氨;
        Desc = "�Դ� ���� ���ظ� {1}��ŭ ���ҽ�ŵ�ϴ�.";

    }
}