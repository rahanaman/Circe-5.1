using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterOnBattleData : CreatureOnBattleData //BattlePanelManager���� ����ϴ� ������
{
    public MonsterID ID { get; private set; }

    public override void Init()
    {
        
    }
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.MonsterBaseList[(int)ID];
    }
}


public abstract class MonsterBase : CreatureBase
{
    public MonsterBase() { } // ����Ʈ ������
    public MonsterBase(int maxHP) { } // ����Ʈ + ü�� ���� �ؾ��ϴ� ���
    

}
