using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MonsterOnBattleData : CreatureOnBattleData<MonsterID> //BattlePanelManager에서 사용하는 데이터
{
    public MonsterID Id { get; private set; }

    protected MonsterActionBase _nextAction;

    public MonsterBase Monster
    {
        get
        {
            return DataBase.Instance.MonsterBaseList[(int)Id];
        }
    }

    
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.MonsterBaseList[(int)Id];
    }

    public override void CallOnTurnBegin()
    {
        
    }

    public override void CallOnTurnEnd()
    {
        GetAction();
    }

    public void InvokeAction()
    {
        _nextAction.Invoke();
    }


    private void GetAction()
    {
        var actions = Monster.GetAction(this);
        int index = Random.Range(0, actions.Count);
        _nextAction = actions[index];
    }

    private void CheckSpecialAction() //  특수 기믹 밯동 여부 확인, 확인 시점 ->몬스터의 값이 변화되었을 때
    {

    }

    public override void Init(MonsterID id)
    {
        Id = id;
    }
}


public abstract class MonsterBase : CreatureBase 
{
    public MonsterBase() { } // 디폴트 생성자

    protected List<MonsterActionBase> _actions;

    public List<MonsterActionBase> GetAction(MonsterOnBattleData data)
    {
        List<MonsterActionBase> actions = new List<MonsterActionBase>();
        foreach (MonsterActionBase action in _actions)
        {
            if (action.IsAvailable(data))
            {
                actions.Add(action);
            }
        }
        return actions;
    }

    //각 몬스터가 가지고 있는 고유 기믹 코딩하는 클래스
    /*    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents; */
}


public sealed class DebugMonster : MonsterBase
{
    public DebugMonster() : base()
    {
        _actions = new List<MonsterActionBase>();
        _actions.Add(new DebugAction(new FlagBase[] { new TurnNumberFlag(2, 0) },"짝수만"));
        _actions.Add(new DebugAction(new FlagBase[] { new TurnNumberFlag(2, 1) },"홀수만"));
    }


}
