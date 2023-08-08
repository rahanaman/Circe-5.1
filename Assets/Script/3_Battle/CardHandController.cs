using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandController : MonoBehaviour // 카드 패 정렬하는 Hand 오브젝트 관리
{
    private Transform _hand;

    private  const int MAXNUM = 10; //손패 최대 장수

    [SerializeField] private Vector3 _rotLeft;
    [SerializeField] private Vector3 _rotRight;

    private float _limit;
    private float _rotLimit = 40f; // 최대 회전 각도
    private float _yLimit = 15f;

    private Vector3 _xleft;
    private Vector3 _xright;

    private List<CardView> _cards = new List<CardView>();

    private void Awake()
    {
        _hand = gameObject.GetComponent<Transform>();
        Init();
        //test();
    }

    private void Init()
    {
        _cards = new List<CardView>();
        _limit = (Screen.width / 8.0f);
        
    }

    public void AddCard(CardView card)
    {
        _cards.Add(card);
        LayoutCard();
    }

     private void LayoutCard()
    {
        int num = _cards.Count;
        float _calLimit = _limit * (float)Math.Log(num, MAXNUM);
        float _calRotLimit = _rotLimit *  (float)Math.Log(num, MAXNUM);

        _xleft = new Vector3(-_calLimit, 0, 0);
        _xright = new Vector3(_calLimit, 0, 0);
        _rotLeft = new Vector3(0,0,_calRotLimit);
        _rotRight = new Vector3(0,0,-_calRotLimit);


        if (num == 1)
        {
            _cards[0].SetTransform(new Vector3(0,0,0), new Vector3(0, 0, 0));
        }
        
        else
        {
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = Vector3.Lerp(_xleft, _xright, (float)i / (num - 1));
                Vector3 rot = Vector3.Lerp(_rotLeft, _rotRight, (float)i / (num - 1));
                //float _caly = 0;
                float _caly = Math.Abs((_yLimit) * rot.z / _rotLimit);
                Vector3 finalPos = new Vector3(pos.x, -_caly, pos.z);
                _cards[i].SetTransform(finalPos, rot);
                
            }
        }
    }

    private void test()
    {
        int num = 5;
        for (int i = 0; i < num; i++)
        {
            Vector3 rot = Vector3.Lerp(_rotLeft, _rotRight, (float)i / (num-1));
            Debug.Log(rot);
        }
    }
}
