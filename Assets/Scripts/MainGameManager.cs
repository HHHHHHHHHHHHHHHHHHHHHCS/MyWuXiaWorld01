using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    private static MainGameManager _instance;

    public static MainGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager")?.GetComponent<MainGameManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("MainGameManager is null");
            }

            return _instance;
        }
    }

    [SerializeField] private MapData mapData;

    public MapManager MapManager;

    public MapData MapData => mapData;


    private void Awake()
    {
        _instance = this;
        MapManager = new MapManager(mapData);
    }
}