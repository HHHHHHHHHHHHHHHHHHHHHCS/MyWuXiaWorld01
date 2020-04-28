using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveTipsFlowController : AbsUIControllerBase
{
    private UITipsWindow window;

    public override void OnAwake()
    {
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