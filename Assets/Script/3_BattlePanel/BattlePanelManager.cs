using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelManager // �̱���
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

    //���� ����

    //ĳ���� �Ӽ� ���� �ݹ� ���

}
