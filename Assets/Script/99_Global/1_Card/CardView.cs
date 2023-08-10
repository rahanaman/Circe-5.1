using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.PlayerSettings;

public class CardView : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _nameRect;
    [SerializeField] private Text _nameText;

    [SerializeField] private RectTransform _descRect;
    [SerializeField] private Scripter _descScripter;

    private CardBase[] CardList() //코드 복잡도 낮추기
    {
        return DataBase.Instance.CardBaseList;
    }

    public void Init(CardID id)
    {
        //string Name, string Desc, KeyValuePair<가중치ID, int>[] 가중치List, int Cost, List<EffectID> EffectList
        SetName(CardList()[(int)id].Name);
        SetDesc(CardList()[(int)id].Desc);
    }


    #region 카드 설명, 이름 설정 및 위치 조정
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

    #endregion 카드 설명, 이름 설정 및 위치 조정


    #region 카드 Tranform 조정 (크기 위치 회전)

    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        transform.localPosition = pos;
        Quaternion q = Quaternion.Euler(rot);
        transform.localRotation = q;
    }
    public void MoveTransform(Vector3 pos, Vector3 rot)
    {
        //_transform.localPosition = pos;
        Quaternion q = Quaternion.Euler(rot);
        _transform.localRotation = q;

        Debug.Log(transform.localPosition); 
        
        transform.DOLocalMove(pos, 0.5f);

        /*
        Sequence seq = DOTween.Sequence();

        seq.Append();
        seq.Join(transform.DOLocalRotate(rot, 0.5f));
        seq.Play();

        */
        
    }

    public void SetScale(float scale)
    {
        _transform.localScale = new Vector3(scale,scale);
    }

    #endregion 카드 Tranform 조정 (크기 위치 회전)
}

