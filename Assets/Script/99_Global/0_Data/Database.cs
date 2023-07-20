using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;



public enum CharID
{
    �ﷹ��,
    ��ų��,
    ��Ƴ�,
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
    CardPanel,
    HandCard,
    Store,
    PrizeCard
}

public enum TriggerID
{
    TurnBegin,
    UseCard,
    OppTurnBegin
    /*
    * Ʈ���� �ߵ� ����:
    * �� ����
    * turnBegin Ʈ���� �ߵ�
    * OppTurnBegin Ʈ���� �ߵ�
    * 
    * �÷��̾� �Ͻ��� -> �÷��̾� ���Ͻ��� Ʈ���� -> ���ʹ� ���Ͻ��� Ʈ���� -> �� �� ���� -> ���ʹ� ���Ͻ��� Ʈ���� -> �÷��̾� ���Ͻ��� Ʈ���� -> �ݺ�
    */

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
                case CharID.��ų��:
                    PlayerBaseList[i] = new Player��ų��Base();
                    break;
                case CharID.��Ƴ�:
                    PlayerBaseList[i] = new Player��Ƴ�Base();
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
