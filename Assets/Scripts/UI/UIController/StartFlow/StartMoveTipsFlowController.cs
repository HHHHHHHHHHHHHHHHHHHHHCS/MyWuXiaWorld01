using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveTipsFlowController : AbsUIControllerBase
{
    private UITipsWindow window;

    //0:未开启  1:玩家位置1检测  2:镜头移动  3:玩家位置2检测
    private byte nowState;

    private bool isFinished;

    private float x, y, w, h;

    private Vector3 startPos;
    private Vector3 endPos = new Vector3(10.24f, 6.5f, -5f);
    private float moveTime = 1f;
    private float moveTimer = 0f;


    private bool moveMainCamera;

    public override void OnAwake()
    {
    }

    public void OnInit(float _x = 0, float _y = 0
        , float _width = 128, float _height = 128)
    {
        x = _x;
        y = _y;
        w = _width;
        h = _height;
    }

    public override void OnShow()
    {
        nowState = 0;
        isFinished = false;
        UITipsWindow.Create(mainUIManager, ShowWindow);
    }

    public void ShowWindow(UITipsWindow _window)
    {
        window = _window;
        window.UpdatePos(x, y, w, h);
        nowState = 1;
    }


    public override void OnUpdate(float deltaTime)
    {
        if (nowState == 1)
        {
            if (isFinished)
            {
                return;
            }

            if (StartMoveTipsFlowCheckAct())
            {
                isFinished = true;
                StartMoveTipsFloEndAct();
            }
        }
        else if (nowState == 2)
        {
            moveTimer += deltaTime;
            if (moveTimer >= moveTime)
            {
                moveTimer = moveTime;
                nowState = 3;
            }

            MainCameraManager.transform.position = Vector3.Lerp(startPos, endPos, moveTimer / moveTime);
        }
    }

    public bool StartMoveTipsFlowCheckAct()
    {
        var pos = PlayerManager.instance.transform.position;

        if (pos.x >= 5.9f && pos.y >= 5.6f && pos.x <= 7.0f && pos.y <= 6.7f)
        {
            return true;
        }

        return false;
    }

    public void StartMoveTipsFloEndAct()
    {
        //鼠标先进点在出点的BUG
        //镜头默认跟随玩家中间  但是处于引导模式的时候锁死   地图边界无所谓

        startPos = MainCameraManager.position;
        moveTimer = 0f;
        nowState = 2;
        moveMainCamera = true;
        window.UpdatePos(0, 0, 0, 0);
    }
}