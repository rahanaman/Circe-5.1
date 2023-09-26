using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class FlagBase
{
    protected BattleController _battleController
    {
        get
        {
            return BattleController.Instance;
        }
    }
    public abstract bool IsAvailable(MonsterOnBattleData data);
}

public class TurnNumberFlag : FlagBase
{
    private int _mod;
    private int[] _rems;

    public TurnNumberFlag(int mod, params int[] rems)
    {
        _mod = mod;
        _rems = rems;
    }
    public override bool IsAvailable(MonsterOnBattleData data)
    {
        int turn = _battleController.TurnNumber;
        int rem = turn - _mod *(int)Math.Truncate((double)turn / _mod);
        foreach (int i in _rems)
        {
            if (rem == i)
            {
                return true;
            }
        }
        return false;
    }
}


public class FlagManager
{

}
