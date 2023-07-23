 using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CardOnBattleData //���̺� �Ǿ���ϴ� ������(�ĵ� ����, ���Ƚ�� ��)
{
    public CardID ID { get; private set; }
    public int[] Data { get; private set; }
}

public abstract class CardBase
{
    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string Desc { get; protected set; }

    public KeyValuePair<����ġID, int>[] ����ġList { get; protected set;}
    public int Cost { get; protected set; }
    public List<EffectID> EffectList { get; protected set;}
    public int[] Data { get; protected set; }
    public abstract void Action();
}


public class Ÿ��Card : CardBase
{
    public Ÿ��Card()
    {
        Desc = "���ظ� {1} �ݴϴ�. <color=olive>�ĵ�</color>: ���ذ� 1 �����մϴ�.";
        Data = new int[] { 5 };
    }
    public override void Action()
    {

    }
}

