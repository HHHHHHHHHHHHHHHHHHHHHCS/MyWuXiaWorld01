﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInfo", menuName = "UnitInfo/PlayerInfo")]
[System.Serializable]
public class PlayerInfo : UnitInfo
{
    public PlayerInfo()
    {
        hp = 100;
        mp = 100;
        moveSpeed = 10;
    }
}
