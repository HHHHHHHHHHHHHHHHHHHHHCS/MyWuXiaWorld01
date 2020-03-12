using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MapManager
{
    public MapData mapData;

    public MapManager(MapData _mapData)
    {
        mapData = _mapData;
    }

    public void CreateDefault()
    {
        Transform root = new GameObject("MapBlock").transform;

        for (int y = 0; y < mapData.MapSizeY; y++)
        {
            var parent = new GameObject("MapParent_" + y).transform;
            parent.transform.localPosition = new Vector3(0, y * mapData.MapSizeY, 0);
            parent.transform.SetParent(root);
            for (int x = 0; x < mapData.MapSizeX; x++)
            {
                GameObject go = Object.Instantiate(mapData.MapPrefab, parent, true);
                go.name = $"MapTile_{y}_{x}";
                go.transform.localPosition = new Vector3(x * mapData.OffsetX, 0, 0);
            }
        }

        UnityEditor.PrefabUtility.SaveAsPrefabAsset(root.gameObject, "Assets/Prefabs/Map/MapBlockBase.prefab");
    }
}