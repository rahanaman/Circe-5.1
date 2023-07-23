using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerOnBattleData : CreatureOnBattleData // BattlePanelManager에서 가지고 있는 Player에 대한 정보. 여기 정보를 기준으로 세이브 데이터 저장
{
    public CharID ID { get; private set;}
    public 속성 속성 { get; private set;}
    public List<CardID> Cards { get; private set; }
    
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }

    public int World { get; private set; }
    public int Stage { get; private set; }
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.PlayerBaseList[(int)ID];
    }
}

public abstract class PlayerBase : CreatureBase
{
    public PlayerBase()
    {
        this.초기속성 = 0;
    }

    public abstract int MaxHP { get; protected set; }
    public abstract List<CardID> Cards { get; protected set; }

    public abstract 속성 초기속성 { get; protected set; }

}

public class Player헬레나Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardID> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player헬레나Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardID>();
    }
}

public class Player아우라Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardID> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player아우라Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardID>();
    }
}

public class Player레아Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardID> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player레아Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardID>();
    }
}

public class Player쥬피테르Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardID> Cards { get; protected set; }
    public override 속성 초기속성 { get; protected set; }

    public Player쥬피테르Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardID>();
    }
}
