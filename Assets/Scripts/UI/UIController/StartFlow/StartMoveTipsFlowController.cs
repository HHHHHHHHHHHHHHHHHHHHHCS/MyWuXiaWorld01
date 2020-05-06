using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveTipsFlowController : AbsUIControllerBase
{
    private UITipsWindow window;
    private Action finishedAction;

    public override void OnAwake()
    {
    }

    public void Show(Action endAct)
    {
        //update finished 检测函数  
        //完成事件
        finishedAction = endAct;
        UITipsWindow.Create(mainUIManager, ShowWindow);
    }

    public void ShowWindow(UITipsWindow _window)
    {
        window = _window;
        window.UpdatePos(-410, -434);
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}