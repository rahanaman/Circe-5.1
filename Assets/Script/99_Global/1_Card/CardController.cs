using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CardController: MonoBehaviour
{
    private ICardHandler _handler;
    
    public CardController() { }


    public void SetMode(CardStateID id)
    {
        switch (id)
        {
            case CardStateID.전투:
                _handler = new 전투CardHandler();
                break;
            case CardStateID.보상:

                break;
            case CardStateID.패널:
                break;
            case CardStateID.도감:
                break;
        }
    }
}


public interface ICardHandler
{
    
    void MouseEnter();
    void MouseDown();
    void MouseExit();
}

public class 전투CardHandler : ICardHandler
{
    public 전투CardHandler()
    {

    }
    
    public void MouseEnter()
    {
        //cardcontroller battlePanel로 전달
    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}

public class 보상CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 패널CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 도감CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}