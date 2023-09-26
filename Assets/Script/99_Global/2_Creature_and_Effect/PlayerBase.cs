using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerOnBattleData : CreatureOnBattleData<CharID> // BattlePanelManager에서 가지고 있는 Player에 대한 정보. 여기 정보를 기준으로 세이브 데이터 저장
{
    public CharID ID { get; private set;}
    public 속성 속성 { get; private set;}
    public List<CardOnBattleData> Cards { get; private set; }

    public override void CallOnTurnBegin()
    {
        throw new System.NotImplementedException();
    }

    public override void CallOnTurnEnd()
    {
        throw new System.NotImplementedException();
    }

    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.PlayerBaseList[(int)ID];
    }

    public override void Init(CharID id)
    {
        ID = id;
    }
}

public abstract class PlayerBase : CreatureBase
{
    public PlayerBase()
    {
        this.초기속성 = 0;
    }

    public abstract int MaxHP { get; protected set; }
    public abstract List<CardOnBattleData> Cards { get; protected set; }

    public abstract 속성 초기속성 { get; protected set; }

}

public class Player헬레나Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player헬레나Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player아우라Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player아우라Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player레아Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player레아Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player쥬피테르Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player쥬피테르Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}
