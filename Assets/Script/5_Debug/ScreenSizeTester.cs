using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeTester : MonoBehaviour
{

    [SerializeField] Dropdown _sizeDropdown;
    [SerializeField] Toggle _sizeToggle;
    [SerializeField] Button _sizeButton;

    private FullScreenMode _screenMode;
    private bool _isFull = false;
    private int _screenValue = 0;

    private List<Resolution> _resolutionList = new List<Resolution>(); // 해상도 변수
    private void Start()
    {
        init();
    }
    private void init()
    {
        _sizeButton.onClick.AddListener(SetScreenSize);
        _isFull = _sizeToggle.isOn;


        foreach (Resolution res in Screen.resolutions)
        {
            if(res.refreshRate == 60)
            {
                _resolutionList.Add(res);
            }
        }

        _sizeDropdown.options.Clear();

        foreach (Resolution resolution in _resolutionList)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData();
            optionData.text = resolution.width + "x" + resolution.height + " " + resolution.refreshRate + "hz";
            _sizeDropdown.options.Add(optionData);
        }

        _sizeDropdown.RefreshShownValue();

        SetDropDown();
    }


    public void CheckScreenValue(int value)
    {
        _screenValue = value;
    }
    

    public void CheckIsFull(bool isFull)
    {
        _isFull = isFull;
        SetDropDown();
    }

    private void SetDropDown()
    {
        if (_isFull)
        {
            _sizeDropdown.interactable = false;
        }
        else _sizeDropdown.interactable = true;
    }

    public void SetScreenSize()
    {
        _screenMode = _isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.SetResolution(_resolutionList[_screenValue].width, _resolutionList[_screenValue].height, _screenMode);
    }



}
