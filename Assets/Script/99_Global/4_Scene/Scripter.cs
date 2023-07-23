using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scripter: MonoBehaviour    //Text를 가지고 있는 GamgObject에 넣어두기
{

    [SerializeField] private bool _hasParent = true; // 상위 객체도 다시 업로드를 해야하는지 (배경이 있는 경우)
    private RectTransform _parentRect;
    private RectTransform _rect;
    private Text _text;

    private void Start()
    {
        if( _hasParent)
        {
            _parentRect = gameObject.transform.parent.GetComponent<RectTransform>();
        }
        _rect = gameObject.GetComponent<RectTransform>();
        _text = gameObject.GetComponent<Text>();
    }
    public void Script(string script) //스크립트 String을 받아와 content 크기에 맞게 조정하는 메소드
    {
        _text.text = script;
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        _parentRect.sizeDelta = new Vector2(_parentRect.rect.width, _rect.rect.height);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(content); 사용하면 된대요!
    }
}
