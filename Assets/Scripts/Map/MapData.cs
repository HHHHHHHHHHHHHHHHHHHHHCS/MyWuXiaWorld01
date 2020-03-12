using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMapData", menuName = "My/MapData")]
[System.Serializable]
public class MapData : ScriptableObject
{
    [SerializeField]
    private GameObject mapPrefab = null;

    [SerializeField]
    private int mapSizeX = 64;

    [SerializeField]
    private int mapSizeY = 64;

    [SerializeField]
    private float startX = 0;

    [SerializeField]
    private float startY = 0;

    [SerializeField]
    private float offsetX = 0.32f;

    [SerializeField]
    private float offsetY = 0.32f;

    public GameObject MapPrefab => mapPrefab;

    public int MapSizeX => mapSizeX;

    public int MapSizeY => mapSizeY;

    public float StartX => startX;

    public float StartY => startY;

    public float OffsetX => offsetX;

    public float OffsetY => offsetY;
}