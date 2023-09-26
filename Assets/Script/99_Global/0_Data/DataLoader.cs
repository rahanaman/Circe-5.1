using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private static DataLoader _instance;
    public static DataLoader Instance
    {
        get
        {
            if(_instance == null)
            {
                throw new System.Exception("DataLoader가 Scene에 없습니다.");
            }
            return _instance;
        }
    }

    [SerializeField] Scripter _effectSub;


    private DataBase _data;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        _data = DataBase.Instance;
        LoadEffectSub();
    }

    public Scripter[] EffectDataList { get; private set; }
    private void LoadEffectSub()
    {
        EffectDataList = new Scripter[Enum.GetValues(typeof(EffectID)).Length];
        for(int i = 0; i < EffectDataList.Length; i++)
        {
            if (_data.EffectDataBaseList[i].Sub == null) continue;
            var scripter = Instantiate(_effectSub,gameObject.transform);
            scripter.Script(_data.EffectDataBaseList[i].Sub);
            EffectDataList[i] = scripter;
            scripter.gameObject.SetActive(false);
        }
    }

}
