 using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CardOnBattleData //���̺� �Ǿ���ϴ� ������(�ĵ� ����, ���Ƚ�� ��)
{
    public CardOnBattleData() { }
    public CardOnBattleData(CardID id)
    {
        ID = id;
        Data = DataBase.Instance.CardBaseList[(int)id].Data;
    }
    public CardOnBattleData(CardID id, int[] data)
    {
        ID = id;
        Data = data;
    }

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

    public string[] Subs { get; protected set; }

    public abstract void Action(params CreatureOnBattleData[] targets);
}


public class Ÿ��Card : CardBase
{
    public Ÿ��Card()
    {
        Name = "Ÿ��";
        Desc = "���ظ� {1} �ݴϴ�. <color=olive>�ĵ�</color>: ���ذ� 1 �����մϴ�.";
        Data = new int[] { 5 };
        Subs = new string[] { "<b>������Ÿ</b>\r\n\r\n��ī��� '���� �� ������'�̶�� ���̾�.��ī��� '���� �� ������'�̶�� ���̾�." };
    }
    public override void Action(params CreatureOnBattleData[] targets)
    {
        int calcData = BattleManager.Instance.GetOnProgressDataCalcs()[(int)BattleDataID.Dmg].Data(Data[0]);
        foreach (var target in targets)
        {
            target.ExecuteGetAction(BattleDataID.Dmg, calcData);
        }
        
    }
}

