using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MonsterOnBattleData : CreatureOnBattleData<MonsterID> //BattlePanelManager���� ����ϴ� ������
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

    private void CheckSpecialAction() //  Ư�� ��� �W�� ���� Ȯ��, Ȯ�� ���� ->������ ���� ��ȭ�Ǿ��� ��
    {

    }

    public override void Init(MonsterID id)
    {
        Id = id;
    }
}


public abstract class MonsterBase : CreatureBase 
{
    public MonsterBase() { } // ����Ʈ ������

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

    //�� ���Ͱ� ������ �ִ� ���� ��� �ڵ��ϴ� Ŭ����
    /*    public Dictionary<TriggerID, TriggeredAction> TriggeredEvents; */
}


public sealed class DebugMonster : MonsterBase
{
    public DebugMonster() : base()
    {
        _actions = new List<MonsterActionBase>();
        _actions.Add(new DebugAction(new FlagBase[] { new TurnNumberFlag(2, 0) },"¦����"));
        _actions.Add(new DebugAction(new FlagBase[] { new TurnNumberFlag(2, 1) },"Ȧ����"));
    }


}
