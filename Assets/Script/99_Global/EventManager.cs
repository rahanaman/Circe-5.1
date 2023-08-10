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


    public CardEvent CardSelected;
    public VoidEvent UpdateCard;


    public void CallOnCardSelected(CardController card)
    {
        CardSelected?.Invoke(card);
    }

    public void CallOnUpdateCard()
    {
        UpdateCard?.Invoke();
    }


}
