using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


public enum DataLoadID //resource���� �о�� �ڷ�� ����
{

}

public enum CharID
{
    �ﷹ��,
    �ƿ��,
    ����,
    �����׸�
}

public enum MonsterID
{
    ����1,
    ����2,
    ����3,
    ����4
}
public enum CardID
{
    ī��1,
    ī��2,
    ī��3
}

public enum EffectID
{
    �氨,
    �ĵ�,
    �买,
    ���,
    �ͻ�,
    �ĵ�����,
    ����

}
public enum SoundID
{
    MainSceneBgm,
    ApolloSelection,
    ScyllaSelection,
    DianaSelection,
    UISound1
}

public enum StateID
{
    Selection,
    Battle,
    Event
}
public enum CardStateID
{
    ����,
    ����,
    �г�,
    ����
}

public enum TriggerID
{
    UseCard,
    TurnBegin,
    TurnEnd,
    OppTurnBegin,
    OppTurnEnd

    /*
    * Ʈ���� �ߵ� ����:
    * �� ����
    * turnBegin Ʈ���� �ߵ�
    * OppTurnBegin Ʈ���� �ߵ�
    * 
    * �÷��̾� ���� ���� Ʈ����-> ���ʹ� �� �� ���� Ʈ���� -> �÷��̾� �� ���� ���� ��ƾ ->�÷��̾� ���� ���� Ʈ���� -> ���ʹ� ���� ���� Ʈ���� -> �÷��̾� �� ���� ���� ��ƾ -> 
    * ���ʹ� ���� ���� Ʈ���� -> �÷��̾� �� �Ͻ��� Ʈ���� -> �� �� ���� ���� ��ƾ -> ���ʹ� ���� ���� Ʈ���� -> �÷��̾� �������� Ʈ���� -> �� �� ���� ���� ��ƾ -> �ݺ�
    */

}

public enum ActionID
{
    Action1,
    Action2,
    Action3,
    Action4,    
    Action5,
    Action6,
    Action7,
    Action8,
    Action9,
    Action10,
    Action11,
    Action12,
}
public enum ����ġID
{
    ���ڸ�,
    Ȳ���ڸ�,
    �ֵ����ڸ�,
    ���ڸ�,
    �����ڸ�,
    ó���ڸ�,
    õĪ�ڸ�,
    �����ڸ�,
    �ü��ڸ�,
    �����ڸ�,
    �����ڸ�,
    ������ڸ�
}

[Flags]
public enum �Ӽ�
{
    �Ӽ�1 = 1,
    �Ӽ�2 = 2,
    �Ӽ�3 = 4,
}


public class DataBase
{
    public PlayerBase[] PlayerBaseList { get; private set; }
    public MonsterBase[] MonsterBaseList { get; private set; }


    private static DataBase _instance;
    public static DataBase Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new DataBase();
            }
            return _instance;
        }
    }
    public DataBase() //�����ڿ� �ʱ�ȭ �Լ��� �־�δ� ���
    {
        GetPlayerBase();
    }

    private void GetPlayerBase() // PlayerBase ����
    {
        PlayerBaseList = new PlayerBase[System.Enum.GetValues(typeof(CharID)).Length];
        for(int i = 0; i < PlayerBaseList.Length; i++)
        {
            switch ((CharID)i)
            {
                case CharID.�ﷹ��:
                    PlayerBaseList[i] = new Player�ﷹ��Base();
                    break;
                case CharID.����:
                    PlayerBaseList[i] = new Player����Base();
                    break;
                case CharID.�ƿ��:
                    PlayerBaseList[i] = new Player�ƿ��Base();
                    break;
                case CharID.�����׸�:
                    PlayerBaseList[i] = new Player�����׸�Base();
                    break;

            }
        }
    }

    private void GetMonsterBase() // MonsterBase ����
    {
        MonsterBaseList = new MonsterBase[System.Enum.GetValues(typeof(MonsterID)).Length];
        for (int i = 0; i < MonsterBaseList.Length; i++)
        {
            switch ((MonsterID)i)
            {
                default:
                break;

            }
        }
    }
}
