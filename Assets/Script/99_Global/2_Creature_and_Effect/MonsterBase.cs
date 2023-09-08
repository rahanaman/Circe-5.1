using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterOnBattleData : CreatureOnBattleData //BattlePanelManager에서 사용하는 데이터
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
    public MonsterBase() { } // 디폴트 생성자
    public MonsterBase(int maxHP) { } // 디폴트 + 체력 설정 해야하는 경우
    

}
