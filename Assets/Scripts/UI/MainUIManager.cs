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

    public AssetReference TargetToLoad;


    private void Awake()
    {
        _instance = this;

        LoadMethod();
    }

    private void OnDisable()
    {
        LoadMethod2();
    }

    public async void LoadMethod()
    {
        var v0 = await Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/UI/TalkWidow.prefab").Task;
        //TargetToLoad.InstantiateAsync().Completed += OnInstantiatedCompleted;
        Addressables.Release(v0);

        var v1 = await Addressables.InstantiateAsync("Assets/Prefabs/UI/TalkWidow.prefab").Task;
        //TargetToLoad.InstantiateAsync().Completed += OnInstantiatedCompleted;
        Addressables.Release(v1);
    }

    public async void LoadMethod2()
    {
        var instance = await Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Human/Player.prefab").Task;
        Addressables.Release(instance);
    }
}