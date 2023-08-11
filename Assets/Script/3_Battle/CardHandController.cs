using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CardHandController : MonoBehaviour // 카드 패 정렬하는 Hand 오브젝트 관리
{
    private Transform _hand;

    private  const int MAXNUM = 10; //손패 최대 장수

    private Vector3 _posLeft;
    private Vector3 _posRight;
    private Vector3 _rotLeft;
    private Vector3 _rotRight;


    public Vector3 _posDelta; // 카드 위에 올려놨을 때 바뀌는 좌표
    private float _posLimit;
    private float _rotLimit = 30f; // 최대 회전 각도
    private float _yLimit = 15f;



    private List<CardController> _cards = new List<CardController>();

    private void Awake()
    {
        EventManager.Instance.CardSelected += OnCardSelected;
        EventManager.Instance.UpdateCard += UpdateCards;

        _hand = gameObject.GetComponent<Transform>();
        Init();
        //test();
    }

    private void OnDestroy()
    {
        EventManager.Instance.CardSelected -= OnCardSelected;
        EventManager.Instance.UpdateCard -= UpdateCards;
    }

    private void Init()
    {
        _cards = new List<CardController>();
        _posLimit = (Screen.width / 8.0f);
        _posDelta = new Vector3((Screen.width / 20.0f),0,0);
        
    }

    public void AddCard(CardController card)
    {
        _cards.Add(card);
        SetCards();
    }

    private void LayoutCards(List<CardController> cards, Vector3 posLeft, Vector3 posRight, Vector3 rotLeft, Vector3 rotRight)
    {
        int num = cards.Count;
        if (num == 1)
        {
            cards[0].MoveTransform(posLeft, rotLeft);
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = Vector3.Lerp(posLeft, posRight, (float)i / (num - 1));
                Vector3 rot = Vector3.Lerp(rotLeft, rotRight, (float)i / (num - 1));
                //float _caly = 0;
                float _caly = Math.Abs((_yLimit) * rot.z / _rotLimit);
                Vector3 finalPos = new Vector3(pos.x, -_caly, pos.z);
                Debug.Log(finalPos);
                cards[i].MoveTransform(finalPos, rot);
            }
        }
    }

    private void UpdateCards()
    {
        foreach (var card in _cards)
        {
            card.UpdateTransform();
        }
    }

    private void SetCards()
    {
        int num = _cards.Count;

        float _calPosLimit = _posLimit * (float)Math.Log(num, MAXNUM); //log10 이 n =1 일때 0인점 활용
        float _calRotLimit = _rotLimit * (float)Math.Log(num, MAXNUM);

        _posLeft = new Vector3(-_calPosLimit, 0, 0);
        _posRight = new Vector3(_calPosLimit, 0, 0);
        _rotLeft = new Vector3(0, 0, _calRotLimit);
        _rotRight = new Vector3(0, 0, -_calRotLimit);
        
        if (num == 1)
        {
            _cards[0].SetTransform(_posLeft, _rotLeft);
            _cards[0].MoveTransform(_posLeft, _rotLeft);
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = Vector3.Lerp(_posLeft, _posRight, (float)i / (num - 1));
                Vector3 rot = Vector3.Lerp(_rotLeft, _rotRight, (float)i / (num - 1));
                //float _caly = 0;
                float _caly = Math.Abs((_yLimit) * rot.z / _rotLimit);
                Vector3 finalPos = new Vector3(pos.x, -_caly, pos.z);
                _cards[i].SetTransform(finalPos, rot);
                _cards[i].MoveTransform(finalPos, rot);
            }
        }

    }


    private void OnCardSelected(CardController card)
    {
        foreach (var c in _cards)
        {
            c.SetScale(0.8f);
        }
        var tmpPos = new Vector3(3f*card.Rot.z, -200,0); // 회전 보정
        //var tmpPos = new Vector3(0,0,0);

        Debug.Log(card.Pos - tmpPos);
        MoveCards(card);
        
        card.MoveTransform((card.Pos - tmpPos), new Vector3(0, 0, 0));
        Debug.Log(card.gameObject.transform.localPosition);
        card.SetScale(1.2f);
    }


    private void MoveCards(CardController card)
    {
        int index = _cards.IndexOf(card);
        
        if (index != 0)
        {
            LayoutCards(_cards.GetRange(0, index), _posLeft - _posDelta, _cards[index - 1].Pos - _posDelta, _rotLeft, _cards[index-1].Rot);
        }
        if(index != _cards.Count-1)
        {
            LayoutCards(_cards.GetRange(index + 1, _cards.Count - index - 1), _cards[index + 1].Pos + _posDelta, _posRight + _posDelta, _cards[index + 1].Rot, _rotRight);
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
