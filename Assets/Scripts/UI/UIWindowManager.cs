using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public static class UIWindowManager
{
    public static Dictionary<Type, AssetReference> windowDictionary
        = new Dictionary<Type, AssetReference>();

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

        if (windowDictionary.TryGetValue(typeof(T), out AssetReference asset))
        {
            AddressManager.LoadAssetReference(asset,
                (obj) =>
                {
                    T window = new T();
                    window.OnCtor(uiManager, obj.transform);
                    act?.Invoke(window);
                });
        }
        else
        {
            Debug.LogError("Can't Find Register Class!");
        }
    }
}