﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
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

    private static InputSystemUIInputModule uiInputModule;

    public static InputSystemUIInputModule UIInputModule
    {
        get
        {
            if (uiInputModule == null)
            {
                uiInputModule = FindObjectOfType<InputSystemUIInputModule>();
            }

            return uiInputModule;
        }
    }

    public static bool IsTouchUI => UIInputModule.IsPointerOverGameObject(Mouse.current.deviceId);


    public UIWindowData uiWindowData;

    public List<UIWindowMonoBase> uiWindowList;

    private void Awake()
    {
        _instance = this;
        uiWindowList = new List<UIWindowMonoBase>();
        UIWindowManager.Init(uiWindowData);
    }

    private void Start()
    {
        UIFlowStep.CreateStartUIFlowController();
    }

    private void Update()
    {
    }
}