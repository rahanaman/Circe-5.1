 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSaveData //세이브 되어야하는 데이터(파도 누적, 사용횟수 등)
{
    public CardID ID { get; private set; }
    public int[] Data { get; private set; }
}

public class CardBase : MonoBehaviour
{
    
}
