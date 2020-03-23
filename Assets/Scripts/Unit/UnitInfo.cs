using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitInfo", menuName = "UnitInfo/UnitInfo")]
[System.Serializable]
public class UnitInfo : ScriptableObject, ICloneable
{
    public string name;
    public int hp;
    public int mp;
    public float moveSpeed;

    public UnitInfo()
    {
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public T Clone<T>() where T : UnitInfo
    {
        return MemberwiseClone() as T;
    }

    public T DepthClone<T>() where T : UnitInfo
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(memoryStream, this);
        memoryStream.Position = 0;
        T o = formatter.Deserialize(memoryStream) as T;
        memoryStream.Dispose();
        return o;
    }
}