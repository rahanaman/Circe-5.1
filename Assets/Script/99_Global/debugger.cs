using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class debugger : MonoBehaviour
{
    
    /*
    [SerializeField] GameObject sub;
    [SerializeField] GameObject SubCon;
    [SerializeField] RectTransform image;
    [SerializeField] Scripter scripter;
     */
    string[] strings = new string[] { "absdfda\r\ndafllkjlkasdjfljasdlkfjsdlfjlskdjflsajdlfjldajfl\r\ndfjlakdjflsajfldjalfjldsakjflsdjlfjslfkjsdlkfjabsdfda\r\ndafllkjlkasdjfljasdlkfjsdlfjlskdjflsajdlfjldajfl\r\ndfjlakdjflsajfldjalfjldsakjflsdjlfjslfkjsdlkfj" };

    [SerializeField] CardController _card;
    [SerializeField] CardHandController _cardHand;
    [SerializeField] Button _button;
    void Start()
    {
        _button.onClick.AddListener(Add);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void Add()
    {
        CardController card = Instantiate(_card, _cardHand.transform);
        card.SetMode(CardStateID.테스트);
        card.Init(CardID.타격);
        card.SetCardData(new CardOnBattleData(CardID.타격));
        _cardHand.AddCard(card);
    }

    /*
    private void 스크립터디버깅()
    {
        text.GetComponent<Text>().text = strings[0];
        LayoutRebuilder.ForceRebuildLayoutImmediate(text.GetComponent<RectTransform>());
        image.sizeDelta = new Vector2(image.rect.width, text.GetComponent<RectTransform>().rect.height);
        LayoutRebuilder.ForceRebuildLayoutImmediate(image.GetComponent<RectTransform>());
     LayoutRebuilder.ForceRebuildLayoutImmediate(_text.GetComponent<RectTransform>());
        Debug.Log(_text.GetComponent<RectTransform>().rect.height);
        Debug.Log(_text.name);
    }
    */
    /*
    private void 스크립터수정()
    {
        GameObject ob = Instantiate(sub, SubCon.transform);
        Instantiate(sub, SubCon.transform);
        ob.GetComponent<Scripter>().Script("absdfda\r\ndafllkjlkasdjfljasdlkfjsdlfjlskdjflsajdlfjldajfl\r\ndfjlakdjflsajflddfadfd\n\nfgfdifhkajsdfjkhfkjhdkhskfhakdjhfkjznjalfjldsakjflsdjlfjslfkjsdlkfj");
    }
    CardView card = Instantiate(_card, _canvas);
        card.SetDesc(strings[0]);
    */
}
