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
            case CardStateID.����:
                _handler = new ����CardHandler();
                break;
            case CardStateID.����:

                break;
            case CardStateID.�г�:
                break;
            case CardStateID.����:
                break;
            case CardStateID.�׽�Ʈ:
                _handler = new �׽�Ʈ��CardHandler();
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

public class �׽�Ʈ��CardHandler : ICardHandler
{
    public �׽�Ʈ��CardHandler() { }
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
    public ����CardHandler()
    {

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