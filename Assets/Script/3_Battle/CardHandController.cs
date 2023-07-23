using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandController : MonoBehaviour // 카드 패 정렬하는 Hand 오브젝트 관리
{
    private Transform _hand;

    [SerializeField] private Vector3 _rotLeft = new Vector3(0,0,40);
    [SerializeField] private Vector3 _rotRight = new Vector3(0, 0, -40);
    private Quaternion _quatLeft;
    private Quaternion _quatRight;
    private List<CardView> _cards = new List<CardView>();

    private void Awake()
    {
        _hand = gameObject.GetComponent<Transform>();
    }

    private void Init()
    {
        _cards = new List<CardView>();
        _quatLeft = Quaternion.Euler(_rotLeft);
        _quatRight = Quaternion.Euler(_rotRight);
    }

    private void AddCard(CardView card)
    {

    }
}
