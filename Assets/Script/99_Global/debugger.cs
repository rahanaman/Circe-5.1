using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugger : MonoBehaviour
{
    string[] strings = new string[] { "absdfda\r\ndafllkjlkasdjfljasdlkfjsdlfjlskdjflsajdlfjldajfl\r\ndfjlakdjflsajfldjalfjldsakjflsdjlfjslfkjsdlkfj" };
    [SerializeField] GameObject sub;
    [SerializeField] GameObject SubCon;
    [SerializeField] RectTransform image;
    [SerializeField] Scripter scripter;
    void Start()
    {
        GameObject ob = Instantiate(sub, SubCon.transform);
        Instantiate(sub, SubCon.transform);
        ob.GetComponent<Scripter>().Script("absdfda\r\ndafllkjlkasdjfljasdlkfjsdlfjlskdjflsajdlfjldajfl\r\ndfjlakdjflsajflddfadfd\n\nfgfdifhkajsdfjkhfkjhdkhskfhakdjhfkjznjalfjldsakjflsdjlfjslfkjsdlkfj");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    /*
    private void a()
    {
        text.GetComponent<Text>().text = strings[0];
        LayoutRebuilder.ForceRebuildLayoutImmediate(text.GetComponent<RectTransform>());
        image.sizeDelta = new Vector2(image.rect.width, text.GetComponent<RectTransform>().rect.height);
        LayoutRebuilder.ForceRebuildLayoutImmediate(image.GetComponent<RectTransform>());
    }
    */
}
