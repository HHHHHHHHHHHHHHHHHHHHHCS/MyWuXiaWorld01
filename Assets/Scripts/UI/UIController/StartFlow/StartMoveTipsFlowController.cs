using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveTipsFlowController : AbsUIControllerBase
{
    private readonly Rect tipsRect = new Rect(new Vector2(-474f, -463f), new Vector2(128f, 128f));
    private readonly Vector3 endPos = new Vector3(6.58f, 3.58f, -5f);
    private readonly Vector4 checkRect = new Vector4(5.5f, 6.2f, 5.8f, 6.4f);


    private UITipsWindow window;

    //0:未开启  1:玩家位置1检测  2:镜头移动  3:玩家位置2检测
    private byte nowState;

    private bool isFinished;

    private Vector3 startPos;

    private float moveTime = 1f;
    private float moveTimer = 0f;


    private bool moveMainCamera;

    public override void OnAwake()
    {
    }

    public void OnInit()
    {
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
        window.UpdatePos(tipsRect.position, tipsRect.size);
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

        if (pos.x >= checkRect.x && pos.y >= checkRect.z && pos.x <= checkRect.y && pos.y <= checkRect.w)
        {
            return true;
        }

        return false;
    }

    public void StartMoveTipsFloEndAct()
    {
        startPos = MainCameraManager.position;
        moveTimer = 0f;
        nowState = 2;
        moveMainCamera = true;
        window.UpdatePos(0, 0, 0, 0);
        PlayerManager.instance.PlayerBehaviour.CanMove = false;
    }
}