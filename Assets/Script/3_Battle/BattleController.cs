using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    [SerializeField] CardHandController _cardHandController;

    public int TurnNumber { get;  set; }

    public static BattleController Instance
    {
        get
        {

            if (_instance == null)
            {
                throw new Exception("BattleController ¾øÀ½");
            }
            else
            {
                return _instance;
            }
        }
    }

    private static BattleController _instance = null;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        
    }


}
