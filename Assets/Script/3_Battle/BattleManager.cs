using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BattleManager 
{
    // �̱���
    private static BattleManager _instance;
    public static BattleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BattleManager();
            }
            return _instance;
        }
    }

    

    private BattleEventManager _battleEventManager = new BattleEventManager(); // EventManager

    public List<CreatureController> Monsters;
    public List<CreatureOnBattleData> MonstersData;

    public CreatureController Player;
    public CreatureOnBattleData PlayerData;

    public CreatureOnBattleData OnProgressData; // ���� �ൿ�� �ϰ� �ִ� creature�� ���� ������

    public DataCalc[] GetOnProgressDataCalcs()
    {
        return OnProgressData.GiveDataCalcs;
    }
    
    public void Init() 
    {

    }
    //���� ����

    //ĳ���� �Ӽ� ���� �ݹ� ���

}
