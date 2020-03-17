using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private PlayerAnim playerAnim;

    public void Awake()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        playerAnim = GetComponent<PlayerAnim>();
    }
}
