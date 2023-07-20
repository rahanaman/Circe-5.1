using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectButtonController : MonoBehaviour
{
    [SerializeField] private CharID _id;
    [SerializeField] private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void OnClickButton() //ĳ���� ���ý� CharID�� ���� ���� ����
    {
        SaveData.Instance.InitSaveData(_id);


        SceneManager.LoadScene("GameScene");
    }

    




}
