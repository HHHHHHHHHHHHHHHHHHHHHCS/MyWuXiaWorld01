using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapPrefabEditor
{
    public const string mapBlockName = "MapBlock_";
    public const string mapParentName = "MapParent_";
    public const string mapTileName = "MapTile_";

    [MenuItem("MapTools/CreateMapBlockDefault")]
    public static void CreateDefault()
    {
        var mapData = GameObject.Find("GameManager")?.GetComponent<MainGameManager>()?.MapData;

        if (mapData == null)
        {
            Debug.LogError("Get mapData is null!");
            return;
        }

        Transform root = new GameObject($"{mapBlockName}Default").transform;
        var block = root.gameObject.AddComponent<MapBlock>();
        block.MapData = mapData;
        for (int y = 0; y < mapData.RowCount; y++)
        {
            var parent = new GameObject("MapParent_" + y).transform;
            parent.transform.localPosition = new Vector3(mapData.StartX, mapData.StartY + y * mapData.OffsetY, 0);
            parent.transform.SetParent(root);
            for (int x = 0; x < mapData.ColumnCount; x++)
            {
                GameObject go = Object.Instantiate(mapData.MapPrefab, parent, true);
                go.name = $"MapTile_{y}_{x}";
                go.transform.localPosition = new Vector3(x * mapData.OffsetX, 0, 0);
            }
        }

        PrefabUtility.SaveAsPrefabAsset(root.gameObject,
            $"Assets/Prefabs/Map/{root.name}.prefab");

        Object.DestroyImmediate(root.gameObject);
    }
}