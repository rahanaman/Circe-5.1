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

public class ����CardHandler : ICardHandler
{
    private CardController _card;
    public ����CardHandler(CardController card)
    {
        _card = card;
    }
    public void MouseEnter()
    {
        //cardcontroller battlePanel�� ����
    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}

public class ����CardHandler : ICardHandler
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
public class �г�CardHandler : ICardHandler
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
public class ����CardHandler : ICardHandler
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