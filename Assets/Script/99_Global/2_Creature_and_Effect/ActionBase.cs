using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase // Battle���� �̷���� �� �ִ� ��� �ൿ 
{
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents; //�����ص� �� ��

    public abstract void Invoke();
    protected abstract void Action(OnBattleData[] targets); //BattlePanelManager���� ������ OnBattleData���� ������ �̷����

}

public abstract class PlayerActionBase : ActionBase
{
    protected PlayerActionBase()
    {
    }
}

public abstract class MonsterActionBase : ActionBase //flagbase�� ������ �ִ� ���� �ൿ����    
{
    private FlagBase[] _flags;

    public MonsterActionBase(FlagBase[] flags)
    {
        _flags = flags;
    }

    protected abstract OnBattleData[] GetTarget();
    public bool IsAvailable(MonsterOnBattleData data)
    {
        foreach (var flag in _flags)
        {
            if (!flag.IsAvailable(data)) return false;
        }
        return true;
    }

}


public class DebugAction : MonsterActionBase
{
    private string _str;
    public DebugAction(FlagBase[] flags) : base(flags) { }

    public DebugAction(FlagBase[] flags, string str): base(flags)
    {
        _str = str;
    }
    public override void Invoke()
    {
        Debug.Log("Debug Action ���� : " + _str);
    }

    protected override void Action(OnBattleData[] targets)
    {
       
    }
    

    protected override OnBattleData[] GetTarget()
    {
        return new PlayerOnBattleData[] { };
    }
}


public class ����Action : ActionBase
{
    public ����Action() { }
    public ����Action(int damage)
    {
        Damage = damage;

    }
    
    public int Damage { get; private set; }

    public override void Invoke()
    {
        
    }

    protected override void Action(OnBattleData[] targets)
    {
        int calcData = BattleManager.Instance.GetOnProgressDataCalcs()[(int)BattleDataID.Dmg].Data(Damage);
        foreach (var target in targets)
        {
            target.ExecuteGetAction(BattleDataID.Dmg, calcData);
        }
    }
}

public class ��Action : ActionBase
{
    public ��Action()
    {

    }

    protected override void Action(params OnBattleData[] targets)
    {
        
    }

    public override void Invoke()
    {
        
    }
}

public class ���Action : ActionBase
{
    public override void Invoke()
    {
       
    }

    protected override void Action(OnBattleData[] targets)
    {
        
    }
}
