using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{

    [SerializeField] private Text _NameText;
    [SerializeField] private RectTransform _NameRect;
    [SerializeField] private Text _DescText;
    [SerializeField] private RectTransform _DescRect;
    
    public void Init(string Name, string Desc, KeyValuePair<가중치ID, int>[] 가중치List, int Cost, List<EffectID> EffectList)
    {
        SetDesc(Desc);
    }
    public void SetDesc(string str)
    {

    } 
}

