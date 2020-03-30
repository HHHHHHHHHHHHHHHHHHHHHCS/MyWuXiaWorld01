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


    private void Awake()
    {
        _instance = this;
        UIWindowManager.Init(uiWindowData);
        var x = new StartFlowUI();
        x.OnCtor(this, this.transform);
        x.OnAwake();
    }
}