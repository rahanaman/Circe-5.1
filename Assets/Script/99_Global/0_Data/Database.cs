using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;



public enum CharID
{
    헬레나,
    스킬라,
    디아나,
    쥬피테르
}

public enum MonsterID
{
    몬스터1,
    몬스터2,
    몬스터3,
    몬스터4
}
public enum CardID
{
    카드1,
    카드2,
    카드3
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
    * 트리거 발동 순서:
    * 턴 시작
    * turnBegin 트리거 발동
    * OppTurnBegin 트리거 발동
    * 
    * 플레이어 턴시작 -> 플레이어 내턴시작 트리거 -> 에너미 적턴시작 트리거 -> 적 턴 시작 -> 에너미 내턴시작 트리거 -> 플레이어 적턴시작 트리거 -> 반복
    */

}






[Flags]
public enum 속성
{
    속성1 = 1,
    속성2 = 2,
    속성3 = 4,
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
    public DataBase() //생성자에 초기화 함수들 넣어두는 방식
    {
        GetPlayerBase();
    }

    private void GetPlayerBase() // PlayerBase 참조
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
                case CharID.쥬피테르:
                    PlayerBaseList[i] = new Player쥬피테르Base();
                    break;

            }
        }
    }

    private void GetMonsterBase() // MonsterBase 참조
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
