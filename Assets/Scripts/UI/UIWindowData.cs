using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "NewUIWindowData", menuName = "My/UIWindowData")]
[System.Serializable]
public class UIWindowData : ScriptableObject
{
    public AssetReference talkWindowAsset;
    public AssetReference screenButtonWindowAsset;
}