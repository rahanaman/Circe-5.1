using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase // Battle에서 이루어질 수 있는 모든 행동 
{
    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents; //제외해도 될 듯

    public abstract void Invoke();
    protected abstract void Action(OnBattleData[] targets); //BattlePanelManager에서 가져온 OnBattleData에서 수정이 이루어짐

}

public abstract class PlayerActionBase : ActionBase
{
    protected PlayerActionBase()
    {
    }
}

public abstract class MonsterActionBase : ActionBase //flagbase를 가지고 있는 몬스터 행동패턴    
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
        Debug.Log("Debug Action 실행 : " + _str);
    }

    protected override void Action(OnBattleData[] targets)
    {
       
    }
    

    protected override OnBattleData[] GetTarget()
    {
        return new PlayerOnBattleData[] { };
    }
}


public class 공격Action : ActionBase
{
    public 공격Action() { }
    public 공격Action(int damage)
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

public class 힘Action : ActionBase
{
    public 힘Action()
    {

    }

    protected override void Action(params OnBattleData[] targets)
    {
        
    }

    public override void Invoke()
    {
        
    }
}

public class 방어Action : ActionBase
{
    public override void Invoke()
    {
       
    }

    protected override void Action(OnBattleData[] targets)
    {
        
    }
}
