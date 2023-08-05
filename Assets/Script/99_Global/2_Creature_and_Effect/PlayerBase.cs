using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerOnBattleData : CreatureOnBattleData // BattlePanelManager���� ������ �ִ� Player�� ���� ����. ���� ������ �������� ���̺� ������ ����
{
    public CharID ID { get; private set;}
    public �Ӽ� �Ӽ� { get; private set;}
    public List<CardOnBattleData> Cards { get; private set; }
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.PlayerBaseList[(int)ID];
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}

public abstract class PlayerBase : CreatureBase
{
    public PlayerBase()
    {
        this.�ʱ�Ӽ� = 0;
    }

    public abstract int MaxHP { get; protected set; }
    public abstract List<CardOnBattleData> Cards { get; protected set; }

    public abstract �Ӽ� �ʱ�Ӽ� { get; protected set; }

}

public class Player�ﷹ��Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override �Ӽ� �ʱ�Ӽ� { get; protected set; }

    public Player�ﷹ��Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player�ƿ��Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override �Ӽ� �ʱ�Ӽ� { get; protected set; }

    public Player�ƿ��Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player����Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override �Ӽ� �ʱ�Ӽ� { get; protected set; }

    public Player����Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}

public class Player�����׸�Base : PlayerBase
{
    public override int MaxHP { get; protected set; }
    public override List<CardOnBattleData> Cards { get; protected set; }
    public override �Ӽ� �ʱ�Ӽ� { get; protected set; }

    public Player�����׸�Base() : base()
    {
        MaxHP = 100;
        Cards = new List<CardOnBattleData>();
    }
}
