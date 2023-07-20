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

    private void OnClickButton() //캐릭터 선택시 CharID에 따라 정보 전달
    {
        SaveData.Instance.InitSaveData(_id);


        SceneManager.LoadScene("GameScene");
    }

    




}
