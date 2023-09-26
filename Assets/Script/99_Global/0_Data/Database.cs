using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.Reflection;

public enum DataLoadID //resource에서 읽어올 자료들 순서
{
    
}

public enum GameStatusID
{
    map,
    battleBegin,
    battleEnd,
    
}

public enum BattleDataID//전투할때 Effect에 의헤 연산이 들어갈 수 있는 데이터
{
    None, // 트리거를 통해 사용되는 부류
    Dmg,
    
    Defence,
    힘,
    익사,
    파도의힘,
    빙결
   

} 

public enum DataCalcID //연산 ID
{
    mult_1,
    add_1,
    mult_2,
    add_2,
    mult_3,
}// 작은 숫자 우선 연산, 같은 숫자에서는 곱셉 우선 연산

public enum CharID
{
    헬레네,
    아우라,
    레아,
    쥬피테르
}

public enum MonsterID
{
    debug
}
public enum CardID
{
    카드1,
    카드2,
    카드3,
    타격
}

public enum EffectID
{
    경감,
    /*
    파도,
    썰물,
    재생,
    익사,
    파도의힘,
    빙결
    */

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
    전투,
    보상,
    패널,
    도감,
    테스트
}

public enum TriggerID
{
    TurnBegin,
    TurnEnd

    /*
    None, // 카드 사용처럼 다른 입력을 통해서 이루어지는 트리거, 루틴 진행에 따라 자동적으로 콜백되어야 하는 트리거를 제외한 모든 트리거
    TurnBegin,
    TurnEnd,
    OppTurnBegin,
    OppTurnEnd

    /*
    * 트리거 발동 순서:
    * 턴 시작
    * turnBegin 트리거 발동
    * OppTurnBegin 트리거 발동
    * 
    * 플레이어 내턴 시작 트리거 -> 에너미 적 턴 시작 트리거 -> 플레이어 턴 시작 고정 루틴 ->플레이어 내턴 종료 트리거 -> 에너미 적턴 종료 트리거 -> 플레이어 턴 종료 고정 루틴 -> 
    * 에너미 내턴 시작 트리거 -> 플레이어 적 턴시작 트리거 -> 적 턴 시작 고정 루틴 -> 에너미 내턴 종료 트리거 -> 플레이어 적턴종료 트리거 -> 적 턴 종료 고정 루틴 -> 반복
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
public enum 가중치ID
{
    양자리,
    황소자리,
    쌍둥이자리,
    게자리,
    사자자리,
    처녀자리,
    천칭자리,
    전갈자리,
    궁수자리,
    염소자리,
    물병자리,
    물고기자리
}

[Flags]
public enum 속성
{
    속성1 = 1,
    속성2 = 2,
    속성3 = 4,
}


public class DataBase //게임 처음으로 실행할 때 해주는 것들
{
    public CardBase[] CardBaseList { get; private set; }
    public PlayerBase[] PlayerBaseList { get; private set; }
    public MonsterBase[] MonsterBaseList { get; private set; }

    public EffectDataBase[] EffectDataBaseList { get; private set; }


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
        GetCardBase();
        GetEffectDataBase();
        GetMonsterBase();
    }

    private void GetPlayerBase() // PlayerBase 참조
    {
        PlayerBaseList = new PlayerBase[Enum.GetValues(typeof(CharID)).Length];
        for(int i = 0; i < PlayerBaseList.Length; i++)
        {
            switch ((CharID)i)
            {
                case CharID.헬레네:
                    PlayerBaseList[i] = new Player헬레나Base();
                    break;
                case CharID.레아:
                    PlayerBaseList[i] = new Player레아Base();
                    break;
                case CharID.아우라:
                    PlayerBaseList[i] = new Player아우라Base();
                    break;
                case CharID.쥬피테르:
                    PlayerBaseList[i] = new Player쥬피테르Base();
                    break;

            }
        }
    }

    private void GetMonsterBase() // MonsterBase 참조
    {
        MonsterBaseList = new MonsterBase[Enum.GetValues(typeof(MonsterID)).Length];
        for (int i = 0; i < MonsterBaseList.Length; i++)
        {
            switch ((MonsterID)i)
            {
                case MonsterID.debug:
                    MonsterBaseList[i] = new DebugMonster();
                    break;
                default:
                break;

            }
        }
    }

    private void GetCardBase()
    {
        CardBaseList = new CardBase[Enum.GetValues(typeof(CardID)).Length];
        for(int i=0;i < CardBaseList.Length; i++)
        {
            switch ((CardID)i)
            {
                case CardID.타격:
                    CardBaseList[i] = new 타격Card();
                    break;
                default:
                    break;
            }
        }
    }

    private void GetMonsterEncounter()
    {

    }


    private void GetEffectDataBase() //effect에 대한 descripion을 로드해옴.
    {  
        EffectDataBaseList = new EffectDataBase[Enum.GetValues(typeof(EffectID)).Length];
        for(int i = 0;i < EffectDataBaseList.Length; i++)
        {
            switch ((EffectID)i)
            {
                case EffectID.경감:
                    EffectDataBaseList[i] = new 경감EffectDataBase();
                    break;
                default:
                    break;

            }
        }
    }

}


public class DataCalc
{
    public double[] factors;

    public DataCalc()
    {
        factors = new double[Enum.GetValues(typeof(DataCalcID)).Length];
        Init();
    }

    private void Init()
    {
        for(int i = 0; i < factors.Length; ++i)
        {
            if((i & 1) == 1) factors[i] = 0.0;// 홀수 - 덧셈
            else factors[i] = 1.0;
        }
    }
    public void GetFactor(DataCalcID id, double data)
    {
        int idx = (int)id;
        if ((idx & 1) == 1)
        {
            factors[idx] += data;
        }
        else
        {
            factors[(int)id] *= data;
        }
    }
    public int Data(int data)
    {
        double calc = data;
        for (int i = 0; i < factors.Length; ++i)
        {
            if ((i & 1) == 1)// 홀수 - 덧셈
            {
                calc += factors[i];
                
            }
            else
            {
                calc *= factors[(int)i];
                calc += 0.01;
                calc = Math.Truncate(calc);
            }
        }
        return (int)Math.Round(calc);
    }
}