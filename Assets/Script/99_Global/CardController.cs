using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController: MonoBehaviour
{
    
}


public interface ICardHandler
{
    void MouseEnter();
    void MouseDown();
    void MouseExit();
}

public class 전투CardHandler : ICardHandler
{
    private CardController _card;
    public 전투CardHandler(CardController card)
    {
        _card = card;
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