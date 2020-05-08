using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveTipsFlowController : AbsUIControllerBase
{
    private UITipsWindow window;
    private Func<bool> updateAction;
    private Action finishedAction;
    private bool isFinished;

    private float x, y, w, h;

    public override void OnAwake()
    {
    }

    public void OnInit(Func<bool> checkAct, Action endAct, float _x = 0, float _y = 0
        , float _width = 128, float _height = 128)
    {
        updateAction = checkAct;
        finishedAction = endAct;
        x = _x;
        y = _y;
        w = _width;
        h = _height;
    }

    public override void OnShow()
    {
        isFinished = false;
        UITipsWindow.Create(mainUIManager, ShowWindow);
    }

    public void ShowWindow(UITipsWindow _window)
    {
        window = _window;
        window.UpdatePos(x, y, w, h);
    }


    public override void OnUpdate()
    {
        if (isFinished)
        {
            return;
        }

        if (updateAction == null)
        {
            isFinished = true;
            finishedAction?.Invoke();
        }
        else if (updateAction())
        {
            finishedAction?.Invoke();
        }
    }
}