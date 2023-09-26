using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.Reflection;

public enum DataLoadID //resource���� �о�� �ڷ�� ����
{
    
}

public enum GameStatusID
{
    map,
    battleBegin,
    battleEnd,
    
}

public enum BattleDataID//�����Ҷ� Effect�� ���� ������ �� �� �ִ� ������
{
    None, // Ʈ���Ÿ� ���� ���Ǵ� �η�
    Dmg,
    
    Defence,
    ��,
    �ͻ�,
    �ĵ�����,
    ����
   

} 

public enum DataCalcID //���� ID
{
    mult_1,
    add_1,
    mult_2,
    add_2,
    mult_3,
}// ���� ���� �켱 ����, ���� ���ڿ����� ���� �켱 ����

public enum CharID
{
    �ﷹ��,
    �ƿ��,
    ����,
    �����׸�
}

public enum MonsterID
{
    debug
}
public enum CardID
{
    ī��1,
    ī��2,
    ī��3,
    Ÿ��
}

public enum EffectID
{
    �氨,
    /*
    �ĵ�,
    �买,
    ���,
    �ͻ�,
    �ĵ�����,
    ����
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
    ����,
    ����,
    �г�,
    ����,
    �׽�Ʈ
}

public enum TriggerID
{
    TurnBegin,
    TurnEnd

    /*
    None, // ī�� ���ó�� �ٸ� �Է��� ���ؼ� �̷������ Ʈ����, ��ƾ ���࿡ ���� �ڵ������� �ݹ�Ǿ�� �ϴ� Ʈ���Ÿ� ������ ��� Ʈ����
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
    * �÷��̾� ���� ���� Ʈ���� -> ���ʹ� �� �� ���� Ʈ���� -> �÷��̾� �� ���� ���� ��ƾ ->�÷��̾� ���� ���� Ʈ���� -> ���ʹ� ���� ���� Ʈ���� -> �÷��̾� �� ���� ���� ��ƾ -> 
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


public class DataBase //���� ó������ ������ �� ���ִ� �͵�
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
    public DataBase() //�����ڿ� �ʱ�ȭ �Լ��� �־�δ� ���
    {
        GetPlayerBase();
        GetCardBase();
        GetEffectDataBase();
        GetMonsterBase();
    }

    private void GetPlayerBase() // PlayerBase ����
    {
        PlayerBaseList = new PlayerBase[Enum.GetValues(typeof(CharID)).Length];
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
                case CardID.Ÿ��:
                    CardBaseList[i] = new Ÿ��Card();
                    break;
                default:
                    break;
            }
        }
    }

    private void GetMonsterEncounter()
    {

    }


    private void GetEffectDataBase() //effect�� ���� descripion�� �ε��ؿ�.
    {  
        EffectDataBaseList = new EffectDataBase[Enum.GetValues(typeof(EffectID)).Length];
        for(int i = 0;i < EffectDataBaseList.Length; i++)
        {
            switch ((EffectID)i)
            {
                case EffectID.�氨:
                    EffectDataBaseList[i] = new �氨EffectDataBase();
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
            if((i & 1) == 1) factors[i] = 0.0;// Ȧ�� - ����
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
            if ((i & 1) == 1)// Ȧ�� - ����
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