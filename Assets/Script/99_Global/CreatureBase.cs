using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public abstract class CreatureOnBattleData
{
    public abstract CreatureBase GetCreatureBase();
}

public class PlayerOnBattleData : CreatureOnBattleData
{
    public CharID ID {  get; private set; }
    public override CreatureBase GetCreatureBase()
    {
        return DataBase.Instance.PlayerBaseList[(int)ID];
    }
}



public abstract class CreatureBase 
{
    //각 크리처가 가지고 있는 고유 기믹 코딩하는 클래스
}


public abstract class PlayerBase:CreatureBase
{

}

public class Player헬레나Base : PlayerBase
{

}

public class Player스킬라Base : PlayerBase
{

}

public class Player디아나Base : PlayerBase
{

}

public class Player테라Base : PlayerBase
{

}
