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
    //�� ũ��ó�� ������ �ִ� ���� ��� �ڵ��ϴ� Ŭ����
}


public abstract class PlayerBase:CreatureBase
{

}

public class Player�ﷹ��Base : PlayerBase
{

}

public class Player��ų��Base : PlayerBase
{

}

public class Player��Ƴ�Base : PlayerBase
{

}

public class Player�׶�Base : PlayerBase
{

}
