using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharID
{
    헬레나,
    스킬라,
    디아나,
    테라
}
public enum CardID
{
    검무
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
}

/*
 * 트리거 발동 순서:
 * 턴 시작
 * turnBegin 트리거 발동
 * OppTurnBegin 트리거 발동
 * 
 * 플레이어 턴시작 -> 플레이어 내턴시작 트리거 -> 에너미 적턴시작 트리거 -> 적 턴 시작 -> 에너미 내턴시작 트리거 -> 플레이어 적턴시작 트리거 -> 반복
*/


public class DataBase
{

    public PlayerBase[] PlayerBaseList;


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
    public DataBase()
    {
        
    }


    

    private void GetPlayerBase()
    {
        PlayerBaseList = new PlayerBase[System.Enum.GetValues(typeof(CharID)).Length];
        for(int i = 0; i < PlayerBaseList.Length; i++)
        {
            switch ((CharID)i)
            {
                case CharID.헬레나:
                    PlayerBaseList[i] = new Player헬레나Base();
                    break;
                case CharID.스킬라:
                    PlayerBaseList[i] = new Player스킬라Base();
                    break;
                case CharID.디아나:
                    PlayerBaseList[i] = new Player디아나Base();
                    break;
                case CharID.테라:
                    PlayerBaseList[i] = new Player테라Base();
                    break;

            }
        }
    }
}
