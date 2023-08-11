using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CardController: MonoBehaviour
{
    [SerializeField]private ICardHandler _handler;
    [SerializeField] CardView _cardview;

    //카드 손패를 위한 기존 위치 저장

    public Vector3 Pos { get; private set; }
    public Vector3 Rot { get; private set; }
    
    

    public void SetMode(CardStateID id)
    {
        switch (id)
        {
            case CardStateID.전투:
                _handler = new 전투CardHandler(this);
                break;
            case CardStateID.보상:

                break;
            case CardStateID.패널:
                break;
            case CardStateID.도감:
                break;
            case CardStateID.테스트:
                _handler = new 테스트용CardHandler(this);
                break;  
        }
    }
    
    public void UpdateTransform()
    {
        _cardview.MoveTransform(Pos, Rot);
        _cardview.SetScale(1.0f);
    }

    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        Pos = pos;
        Rot = rot;
    }

    public void SetViewTransform(Vector3 pos, Vector3 rot)
    {
        _cardview.SetTransform(pos, rot);
    }

    public void MoveTransform(Vector3 pos, Vector3 rot)
    {
        _cardview.MoveTransform(pos, rot);
    }

    public void SetScale(float scale)
    {
        _cardview.SetScale(scale);
    }

    private void OnMouseDown()
    {
        if(_handler != null)
        {
            _handler.MouseDown();
        }
    }

    private void OnMouseEnter()
    {
        if (_handler != null)
        {
            _handler.MouseEnter();
        }
        
    }

    private void OnMouseExit()
    {
        if (_handler != null)
        {
            _handler.MouseExit();
        }
       
    }
}


public interface ICardHandler
{
    void MouseEnter();
    void MouseDown();
    void MouseExit();
}

public abstract class CardHandler : ICardHandler
{
    protected CardController _cardController;
    public CardHandler(CardController cardController)
    {
        _cardController = cardController;
    }
    public abstract void MouseDown();

    public abstract void MouseEnter();


    public abstract void MouseExit();

    protected void SelectCard()
    {

        EventManager.Instance.CallOnCardSelected(_cardController);
    }
    
}

public class 테스트용CardHandler : CardHandler
{
    private bool _isWorking = false;
    public 테스트용CardHandler(CardController cardController) : base(cardController)
    {
        _cardController.SetViewTransform(new Vector3(-1200,0,0),new Vector3 (0,0,0));
    }

    private void WorkDone()
    {
        _isWorking = false;
    }

    public override void MouseEnter()
    {
        //cardcontroller battlePanel로 전달
        Debug.Log("마우스 들어옴");
        SelectCard();
    }
    public override void MouseDown()
    {
        Debug.Log("마우스 클릭");
        
    }

    public override void MouseExit()
    {
        
        Debug.Log("마우스 나감");
        EventManager.Instance.CallOnUpdateCard();

    }
}

public class 전투CardHandler : CardHandler
{
    public 전투CardHandler(CardController cardController) : base(cardController)
    {

    }
    
    public override void MouseEnter()
    {
        //cardcontroller battlePanel로 전달
    }
    public override void MouseDown()
    {

    }

    public override void MouseExit()
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