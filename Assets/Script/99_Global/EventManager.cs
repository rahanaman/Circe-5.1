using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private static EventManager _instance;


    public static EventManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new EventManager();
            }
            return _instance;
        }
    }

    public EventManager()
    {

    }

    public delegate void CardEvent(CardController card);
    public delegate void VoidEvent();



    public CardEvent CardMouseOver;
    public VoidEvent UpdateCard;
    public CardEvent DeleteCard;


    public void CallOnCardMouseOver(CardController card)
    {
        CardMouseOver?.Invoke(card);
    }

    public void CallOnUpdateCard()
    {
        UpdateCard?.Invoke();
    }
    
    public void CallOnDeleteCard(CardController card)
    {
        DeleteCard?.Invoke(card);
    }

}
