using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectDataBase //effect�� subscription ���� ������ ���� ����
{
    public string Sub { get; protected set; }

    public EffectDataBase()
    {

    }
}


public sealed class �氨EffectDataBase : EffectDataBase
{
    public �氨EffectDataBase()
    {
        Sub = "<b>�氨</b>\n\n�Դ� ���� ���ظ� {0}��ŭ ���ҽ�ŵ�ϴ�.";
    }
}