using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public static class UIWindowManager
{
    public static UIWindowData uiWindowData;

    public static void Init(UIWindowData _uiWindowData)
    {
        uiWindowData = _uiWindowData;

    }

    public static void CreateWindow<T>(MainUIManager uiManager, Action<T> act)
        where T : UIWindowMonoBase, new()
    {
        if (uiWindowData == null)
        {
            Debug.LogError("UIWindowData is null!");
            return;
        }

        if (typeof(T) == typeof(UITalkWindow))
        {
            uiWindowData.talkWindowAsset.LoadAssetAsync<GameObject>().Completed += operation =>
            {
                var instObj = Object.Instantiate(operation.Result);
                T window = new T();
                window.OnCtor(uiManager, instObj.transform);
                act(window);
                Addressables.Release(operation.Result);
            };
        }
        else
        {
            Debug.LogError("Can't Find Register Class!");
        }
    }
}