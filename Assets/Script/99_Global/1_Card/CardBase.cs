 using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CardOnBattleData //세이브 되어야하는 데이터(파도 누적, 사용횟수 등)
{
    public CardID ID { get; private set; }
    public int[] Data { get; private set; }
}

public abstract class CardBase
{
    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    public KeyValuePair<가중치ID, int>[] 가중치List { get; protected set;}
    public int Cost { get; protected set; }
    public List<EffectID> EffectList { get; protected set;}
    public abstract void Action();
}


public class 타격Card : CardBase
{
    public override void Action()
    {

    }
}

