using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Scripter: MonoBehaviour    //Text�� ������ �ִ� GamgObject�� �־�α�
{
    /// <summary>
    /// �ؽ�Ʈ UI ������ Recttransform�� ���� �θ������Ʈ�� �־�α�
    /// ���� textUI�� RectTransform+contentsizefitter, Pivot�� 0.5, 1���� ����
    /// </summary>
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
    public void Script(string script) //��ũ��Ʈ String�� �޾ƿ� content ũ�⿡ �°� �����ϴ� �޼ҵ�
    {

        _text.text = script;
        UpdateScript();
        //LayoutRebuilder.ForceRebuildLayoutImmediate(content); ����ϸ� �ȴ��!
    }

    public void UpdateScript()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        _parentRect.sizeDelta = new Vector2(_parentRect.rect.width, _rect.rect.height + 2 * _yDelta); //
        LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
    }
}
