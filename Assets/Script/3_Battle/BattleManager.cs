using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BattleManager 
{
    // 싱글톤
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

    public CreatureOnBattleData OnProgressData; // 현재 행동을 하고 있는 creature에 대한 데이터

    public DataCalc[] GetOnProgressDataCalcs()
    {
        return OnProgressData.GiveDataCalcs;
    }
    
    public void Init() 
    {

    }
    //전투 시작

    //캐릭터 속성 관련 콜백 등록

}
