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
    加己,
    World,
    Stage
}

public class SaveData
{
    private static string SAVE = "save";

    private CharID _id;
    
    
    private int _maxHP;
    private int _currentHP;
    private List<CardID> _cards;
    private 加己 _加己;
    private int _world;
    private int _stage;

    /*
     * 技捞宏肺靛 叼滚弊 抛胶飘侩
    private void Start()
    {

        Load();
        _maxHP = 100;
        _currentHP = 50;
        _cards = new List<CardID>() { CardID.墨靛1, CardID.墨靛1, CardID.墨靛3 };
        _加己 = 加己.加己1 | 加己.加己3;
        _world = 3;
        _stage = 1;

        Save();
        Load();
        

    }
    */

    public void InitSaveData(CharID id)
    {

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
                List<CardID> SetCardList()
                {
                    var cardArr = data.Split(','); 
                    List<CardID> cards = new List<CardID>();
                    foreach(var card in cardArr)
                    {
                        cards.Add((CardID)int.Parse(card));
                    }
                    return cards;
                }
                break;
            case SaveDataField.加己:
                _加己 = (加己)int.Parse(data);
                break;
            case SaveDataField.World:
                _world = int.Parse(data);
                break;
            case SaveDataField.Stage:
                _stage = int.Parse(data);
                break;
        }
    }

    private String[] GetSaveData() //技捞宏params 罐酒坷扁
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
            for(int i = 0; i< len; ++i)
            {
                str += (int)_cards[i]+",";
            }

            str = str.Substring(0, str.Length - 1);

            return str;
        }
        //加己
        saveFile.Add((int)_加己+"");
        //world 柳青档
        saveFile.Add(_world+"");
        //stage柳青档
        saveFile.Add(_stage+"");
        return saveFile.ToArray();
    }

    

    public void Save()
    {
        string prefs = CSVReader.Write(GetSaveData());
        PlayerPrefs.SetString(SAVE, prefs);

        Debug.Log("Save肯丰");

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SAVE))
        {
            var data = CSVReader.Read(PlayerPrefs.GetString(SAVE));
            int len = Enum.GetValues(typeof(SaveDataField)).Length;
            for (int i =0; i<len; ++i){
                

                LoadSaveData((SaveDataField)i, data[i]);
            }
        }
        else
        {
            Debug.Log("Save 颇老 绝澜");
        }
    }

}

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static string Write(params string[] data)
    {
        string saveFile = "";
        foreach (string s in data)
        {
            saveFile += "\"" + s + "\"";
            saveFile += ",";
            Debug.Log(saveFile);
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
}
