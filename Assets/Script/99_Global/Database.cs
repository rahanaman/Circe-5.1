using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharID
{
    �ﷹ��,
    ��ų��,
    ��Ƴ�,
    �׶�
}
public enum CardID
{
    �˹�
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
 * Ʈ���� �ߵ� ����:
 * �� ����
 * turnBegin Ʈ���� �ߵ�
 * OppTurnBegin Ʈ���� �ߵ�
 * 
 * �÷��̾� �Ͻ��� -> �÷��̾� ���Ͻ��� Ʈ���� -> ���ʹ� ���Ͻ��� Ʈ���� -> �� �� ���� -> ���ʹ� ���Ͻ��� Ʈ���� -> �÷��̾� ���Ͻ��� Ʈ���� -> �ݺ�
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
                case CharID.�ﷹ��:
                    PlayerBaseList[i] = new Player�ﷹ��Base();
                    break;
                case CharID.��ų��:
                    PlayerBaseList[i] = new Player��ų��Base();
                    break;
                case CharID.��Ƴ�:
                    PlayerBaseList[i] = new Player��Ƴ�Base();
                    break;
                case CharID.�׶�:
                    PlayerBaseList[i] = new Player�׶�Base();
                    break;

            }
        }
    }
}
