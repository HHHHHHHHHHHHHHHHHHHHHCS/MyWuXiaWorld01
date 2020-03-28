using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public class AddressManager
{
    public static void LoadAndRelease<T>(string path, Action<T> act) where T : Object
    {
        Addressables.LoadAssetAsync<T>(path).Completed += (res) =>
        {
            var ins = Object.Instantiate(res.Result);
            act(ins);
            Addressables.Release(res.Result);
        };
    }

    public static void LoadAsset<T>(string path, Action<T> act) where T : Object
    {
        Addressables.LoadAssetAsync<T>(path).Completed += (res) => { act(res.Result); };
    }

    public static void ReleaseAsset<T>(T obj) where T : Object
    {
        Addressables.Release(obj);
    }

    public static void InstantiateGameObject(string path, Action<GameObject> act)
    {
        Addressables.InstantiateAsync(path).Completed += (res) => { act(res.Result); };
    }

    public static void ReleaseInstance(GameObject obj)
    {
        Addressables.ReleaseInstance(obj);
    }
}