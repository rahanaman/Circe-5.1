using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectDataBase //effect의 subscription 참조 데이터 정보 보관
{
    public string Sub { get; protected set; }

    public EffectDataBase()
    {

    }
}


public sealed class 경감EffectDataBase : EffectDataBase
{
    public 경감EffectDataBase()
    {
        Sub = "<b>경감</b>\n\n입는 공격 피해를 {0}만큼 감소시킵니다.";
    }
}