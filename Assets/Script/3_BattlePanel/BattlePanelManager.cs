using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelManager // 싱글톤
{

    private BattlePanelManager _instance;
    public BattlePanelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BattlePanelManager();
            }
            return _instance;
        }
    }

    private BattleEventManager _battleEventManager = new BattleEventManager();

    //전투 시작

    //캐릭터 속성 관련 콜백 등록

}
