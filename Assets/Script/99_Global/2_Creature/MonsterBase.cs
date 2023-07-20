using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterOnBattleData : CreatureOnBattleData
{
    public MonsterID ID { get; private set; }
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.MonsterBaseList[(int)ID];
    }
}


public class MonsterBase : CreatureBase
{

}
