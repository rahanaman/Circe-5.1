 using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CardOnBattleData //세이브 되어야하는 데이터(파도 누적, 사용횟수 등)
{
    public CardOnBattleData() { }
    public CardOnBattleData(CardID id)
    {
        ID = id;
        Data = DataBase.Instance.CardBaseList[(int)id].Data;
    }
    public CardOnBattleData(CardID id, int[] data)
    {
        ID = id;
        Data = data;
    }

    public CardID ID { get; private set; }
    public int[] Data { get; private set; }
}

public abstract class CardBase
{
    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string Desc { get; protected set; }

    public KeyValuePair<가중치ID, int>[] 가중치List { get; protected set;}
    public int Cost { get; protected set; }
    public List<EffectID> EffectList { get; protected set;}
    public int[] Data { get; protected set; }

    public EffectID[] Subs { get; protected set; }


    public abstract void Action(OnBattleData[] targets);
}


public class 타격Card : CardBase
{
    public 타격Card()
    {
        Name = "타격";
        Desc = "피해를 {0} 줍니다. <color=olive>파도</color>: 피해가 1 증가합니다.";
        Data = new int[] { 5 };

        //Subs = new EffectID[] { EffectID.경감 };
    }
    public override void Action(OnBattleData[] targets)
    {
        int calcData = BattleManager.Instance.GetOnProgressDataCalcs()[(int)BattleDataID.Dmg].Data(Data[0]);
        foreach (var target in targets)
        {
            target.ExecuteGetAction(BattleDataID.Dmg, calcData);
        }
        
    }
}

