using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Linq;
using JetBrains.Annotations;

public enum SaveDataField
{
    MaxHP,
    CurrentHP,
    Cards,
    �Ӽ�,
    Effect,
    World,
    Stage,
    GameStatus
}

public class SaveData
{
    private static string SAVE = "save";

    private static SaveData _instance;
    public static SaveData Instance //�̱���
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveData();
            }
            return _instance;
        }
    }
    public SaveData(){ //������

    }



    private CharID _id;
    private int _maxHP;
    private int _currentHP;
    private List<CardOnBattleData> _cards;
    private List<EffectOnBattleData> _effects;
    private �Ӽ� _�Ӽ�;
    private int _world;
    private int _stage;
    private GameStatusID _gameStatus;




    public void InitSaveData(CharID id)
    {
        PlayerBase playerBase = DataBase.Instance.PlayerBaseList[(int)id];
        _maxHP = playerBase.MaxHP;
        _currentHP = playerBase.MaxHP;
        _cards = playerBase.Cards;
        _�Ӽ� = playerBase.�ʱ�Ӽ�;
        _world = 0;
        _stage = 0;
        _gameStatus = GameStatusID.map;

    }

    public void Save()
    {
        string prefs = CSVReader.Write(GetSaveData());
        Debug.Log(prefs);
        PlayerPrefs.SetString(SAVE, prefs);

        Debug.Log("Save�Ϸ�");

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SAVE))
        {
            var data = CSVReader.Read(PlayerPrefs.GetString(SAVE));
            int len = Enum.GetValues(typeof(SaveDataField)).Length;
            for (int i = 0; i < len; ++i)
            {


                LoadSaveData((SaveDataField)i, data[i]);
            }
        }
        else
        {
            Debug.Log("Save ���� ����");
        }
    }

    public void Remove() //���� Ŭ���� �� ���� ���� ������ ����
    {
        PlayerPrefs.DeleteKey(SAVE);
    }


    private void LoadSaveData(SaveDataField field, string data)
    {
        switch (field)
        {
            case SaveDataField.MaxHP:
                _maxHP = int.Parse(data);
                break;
            case SaveDataField.CurrentHP:
                _currentHP = int.Parse(data);
                break;
            case SaveDataField.Cards:
                _cards = SetCardList();
                List<CardOnBattleData> SetCardList()
                {
                    var cardArr = CSVReader.ReadCard(data);
                    List<CardOnBattleData> cards = new List<CardOnBattleData>();
                    foreach(var card in cardArr)
                    {
                        var arr = card.Split(',');
                        
                        var data = Array.ConvertAll(arr, int.Parse);

                        CardOnBattleData cardData = new CardOnBattleData((CardID)data[0],data.Skip(1).ToArray());
                        cards.Add(cardData);
                    }
                    return cards;
                }
                break;
            case SaveDataField.Effect:
                _effects = SetEffectList();
                List<EffectOnBattleData> SetEffectList()
                {
                    var effectArr = CSVReader.ReadCard(data);
                    List<EffectOnBattleData> effects = new List<EffectOnBattleData>();
                    foreach (var effect in effectArr)
                    {
                        var arr = effect.Split(',');

                        var data = Array.ConvertAll(arr, int.Parse);

                        EffectOnBattleData effectData = new EffectOnBattleData((EffectID)data[0], data.Skip(1).ToArray());
                        effects.Add(effectData);
                    }
                    return effects;
                }
                break;
            case SaveDataField.�Ӽ�:
                _�Ӽ� = (�Ӽ�)int.Parse(data);
                break;
            case SaveDataField.World:
                _world = int.Parse(data);
                break;
            case SaveDataField.Stage:
                _stage = int.Parse(data);
                break;
            case SaveDataField.GameStatus:
                _gameStatus =(GameStatusID) int.Parse(data);
                break;
        }
    }

    private String[] GetSaveData() //���̺�params �޾ƿ���
    {
        List<string> saveFile = new List<string>();
        //maxHP
        saveFile.Add(_maxHP + "");
        //currentHP
        saveFile.Add(_currentHP + "");
        //cards
        saveFile.Add(GetCardList());
        string GetCardList()
        {
            string str = "";
            int len = _cards.Count;
            for (int i = 0; i < len; ++i)
            {
                str += "\'";
                str += (int)_cards[i].ID + ",";
                foreach (int data in _cards[i].Data)
                {
                    str += data + ",";
                }
                str = str.Substring(0, str.Length - 1);
                str += "\',";
            }

            str = str.Substring(0, str.Length - 1);

            return str;
        }
        //�Ӽ�
        saveFile.Add((int)_�Ӽ� + "");
        //effect
        saveFile.Add(GetEffectList());
        string GetEffectList()
        {
            string str = "";
            int len = _effects.Count;
            for (int i = 0; i < len; ++i)
            {
                str += "\'";
                str += (int)_effects[i].ID + ",";
                foreach (int data in _effects[i].Data)
                {
                    str += data + ",";
                }
                str = str.Substring(0, str.Length - 1);
                str += "\',";
            }

            str = str.Substring(0, str.Length - 1);

            return str;
        }
        //world ���൵
        saveFile.Add(_world+"");
        //stage���൵
        saveFile.Add(_stage+"");
        //game status
        saveFile.Add((int)_gameStatus + "");
        return saveFile.ToArray();
    }

    

    
}

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string CARD_SPLIT_RE = @",(?=(?:[^']*'[^']*')*(?![^']*'))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };
    static char[] CARD_TRIM_CHARS = { '\'' };

    public static string Write(params string[] data)
    {
        string saveFile = "";
        foreach (string s in data)
        {
            saveFile += "\"" + s + "\"";
            saveFile += ",";
        }
        saveFile = saveFile = saveFile.Substring(0, saveFile.Length - 1);

        return saveFile;
    }
    public static string[] Read(string file)
    {
        
        var values = Regex.Split(file, SPLIT_RE);
        int len = values.Length;
        for (int i = 0;i<len;++i)
        {
            values[i] = values[i].TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
        }
        return values;
        
    }

    public static string[] ReadCard(string file)
    {
        var values = Regex.Split(file, CARD_SPLIT_RE);
        int len = values.Length;
        for (int i = 0; i < len; ++i)
        {
            values[i] = values[i].TrimStart(CARD_TRIM_CHARS).TrimEnd(CARD_TRIM_CHARS).Replace("\\", "");
        }
        return values;
    }
}


/*
 * ���̺�ε� ����� �׽�Ʈ��
private void Start()
{

    Load();
    _maxHP = 100;
    _currentHP = 50;
    _cards = new List<CardID>() { CardID.ī��1, CardID.ī��1, CardID.ī��3 };
    _�Ӽ� = �Ӽ�.�Ӽ�1 | �Ӽ�.�Ӽ�3;
    _world = 3;
    _stage = 1;

    Save();
    Load();


}

//1�� ����
private void Start()
{

    //Load();
    _maxHP = 100;
    _currentHP = 50;
    _cards = new List<CardOnBattleData>()
    {
        new CardOnBattleData(CardID.ī��1, new int[]{ 1,0}),
        new CardOnBattleData(CardID.ī��1, new int[]{ 1,1}),
        new CardOnBattleData(CardID.ī��2, new int[]{}),

    };
    _�Ӽ� = �Ӽ�.�Ӽ�1 | �Ӽ�.�Ӽ�3;
    _world = 3;
    _stage = 1;

    Save();
    Load();
    foreach(var card in _cards)
    {
        Debug.Log(card.ID);
        foreach(int data in card.Data)
        {
            Debug.Log(data);
        }
        Debug.Log(card.ID+" ��");
    }



}
*///���̺� �ε� �����