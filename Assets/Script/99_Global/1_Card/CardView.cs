using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _nameRect;
    [SerializeField] private Text _nameText;

    [SerializeField] private RectTransform _descRect;
    [SerializeField] private Scripter _descScripter;

    private CardBase[] CardList()
    {
        return DataBase.Instance.CardBaseList;
    }
    public void Init(CardID id)
    {
        //string Name, string Desc, KeyValuePair<가중치ID, int>[] 가중치List, int Cost, List<EffectID> EffectList
        SetName(CardList()[(int)id].Name);
        SetDesc(CardList()[(int)id].Desc);
    }
    public void SetDesc(string str)
    {
        _descScripter.Script(str);
        SetNamePos();
    }

    private void SetName(string str)
    {
        _nameText.text = str;
    }
    public void SetNamePos()
    {
        var posY = _descRect.rect.height;
        _nameRect.anchoredPosition = new Vector2(_nameRect.anchoredPosition.x,posY);
    }

}

