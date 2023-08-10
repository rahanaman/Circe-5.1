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

    private CardBase[] CardList() //�ڵ� ���⵵ ���߱�
    {
        return DataBase.Instance.CardBaseList;
    }

    public void Init(CardID id)
    {
        //string Name, string Desc, KeyValuePair<����ġID, int>[] ����ġList, int Cost, List<EffectID> EffectList
        SetName(CardList()[(int)id].Name);
        SetDesc(CardList()[(int)id].Desc);
    }


    #region ī�� ����, �̸� ���� �� ��ġ ����
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

    #endregion ī�� ����, �̸� ���� �� ��ġ ����


    #region ī�� Tranform ���� (ũ�� ��ġ ȸ��)

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

    #endregion ī�� Tranform ���� (ũ�� ��ġ ȸ��)
}

