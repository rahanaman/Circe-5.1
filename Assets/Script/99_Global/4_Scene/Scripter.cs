using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scripter: MonoBehaviour    //Text�� ������ �ִ� GamgObject�� �־�α�
{

    [SerializeField] private bool _hasParent = true; // ���� ��ü�� �ٽ� ���ε带 �ؾ��ϴ��� (����� �ִ� ���)
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
    public void Script(string script) //��ũ��Ʈ String�� �޾ƿ� content ũ�⿡ �°� �����ϴ� �޼ҵ�
    {
        _text.text = script;
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        _parentRect.sizeDelta = new Vector2(_parentRect.rect.width, _rect.rect.height);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(content); ����ϸ� �ȴ��!
    }
}
