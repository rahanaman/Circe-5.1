using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandController : MonoBehaviour // 카드 패 정렬하는 Hand 오브젝트 관리
{
    private Transform _hand;

    [SerializeField] private Vector3 _rotLeft = new Vector3(0,0,40);
    [SerializeField] private Vector3 _rotRight = new Vector3(0, 0, -40);

    [SerializeField] private Vector3 _xleft = new Vector3(-50, 0, 0);
    [SerializeField] private Vector3 _xright = new Vector3(50, 0, 0);

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
        
    }

    public void AddCard(CardView card)
    {
        _cards.Add(card);
        LayoutCard();
    }

     private void LayoutCard()
    {
        int num = _cards.Count;
        if(num == 1)
        {
            _cards[0].SetTransform(new Vector3(0,0,0), new Vector3(0, 0, 0));
        }
        else if (num > 2)
        {
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = Vector3.Lerp(_xright, _xleft, (float)i / (num - 1));
                Vector3 rot = Vector3.Lerp(_rotLeft, _rotRight, (float)i / (num - 1));
                _cards[i].SetTransform(pos, rot);
            }
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = Vector3.Lerp(_xright, _xleft, (float)i / (num-1));
                _cards[i].SetTransform(pos, new Vector3(0, 0, 0));
                
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
