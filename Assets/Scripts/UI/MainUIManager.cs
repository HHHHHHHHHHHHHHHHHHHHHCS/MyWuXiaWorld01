using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MainUIManager : MonoBehaviour
{
    private static MainUIManager _instance;

    public static MainUIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<MainUIManager>();
            return _instance;
        }
    }

    public UIWindowData uiWindowData;

    private UITalkWindow talkWindow;

    private void Awake()
    {
        _instance = this;
        UIWindowManager.Init(uiWindowData);
        UIWindowManager.CreateWindow<UITalkWindow>(this, CreateTalkWindow);
    }

    public void CreateTalkWindow(UITalkWindow newTalkWindow)
    {
        talkWindow = newTalkWindow;
        newTalkWindow.SetNameContext("xx", ".........");
        newTalkWindow.AddClickButton("a", ()=>{});
    }
}