using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Scripter: MonoBehaviour    //Text를 가지고 있는 GamgObject에 넣어두기
{
    private RectTransform _parentRect;
    private RectTransform _rect;
    private Text _text;
    private float _yDelta;

    private void Awake()
    {
        _parentRect = GetComponent<RectTransform>();
        _rect = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        _text = gameObject.transform.GetChild(0).GetComponent<Text>();
        _yDelta = Math.Abs(gameObject.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y);
    }
    public void Script(string script) //스크립트 String을 받아와 content 크기에 맞게 조정하는 메소드
    {

        _text.text = script;
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        _parentRect.sizeDelta = new Vector2(_parentRect.rect.width, _rect.rect.height+2*_yDelta); //
        LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(content); 사용하면 된대요!
    }
}
