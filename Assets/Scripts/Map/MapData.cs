using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMapData", menuName = "My/MapData")]
[System.Serializable]
public class MapData : ScriptableObject
{
    [SerializeField] private GameObject mapPrefab = null;

    [SerializeField] private int columnCount = 32;

    [SerializeField] private int rowCount = 32;

    [SerializeField] private float startX = 0;

    [SerializeField] private float startY = 0;

    [SerializeField] private float offsetX = 0.64f;

    [SerializeField] private float offsetY = 0.64f;

    public GameObject MapPrefab => mapPrefab;

    public int ColumnCount => columnCount;

    public int RowCount => rowCount;

    public float StartX => startX - columnCount / 2f * offsetX;

    public float StartY => startY - rowCount / 2f * offsetY;

    public float OffsetX => offsetX;

    public float OffsetY => offsetY;
}