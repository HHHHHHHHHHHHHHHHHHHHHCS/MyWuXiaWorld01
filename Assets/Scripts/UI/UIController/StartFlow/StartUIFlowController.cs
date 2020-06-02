using System;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class StartUIFlowController : AbsUIControllerBase
{
    private UIScreenButtonWindow window;
    private Action finishedAct;

    public override void OnAwake()
    {
    }

    public void Init(Action endAct)
    {
        finishedAct = endAct;
    }

    public override void OnShow()
    {
        UIScreenButtonWindow.Create(mainUIManager, ShowWindow);
    }

    public void ShowWindow(UIScreenButtonWindow _window)
    {
        window = _window;
        window.SetImageAndText(null, "又能偷看小慧洗澡了,嘿嘿嘿!");
        window.SetNextButtonEvent(Flow1);
    }

    public void Flow1()
    {
        window.SetImageAndText("Assets/Textures/Backgrounds/TouKan.tga", null);
        window.SetNextButtonEvent(Flow2);
    }

    public void Flow2()
    {
        window.SetImageAndText(null, "是哪个混蛋在窗外!!!\n看老娘不砍死你!!!");
        window.SetNextButtonEvent(Flow3);
    }

    public void Flow3()
    {
        Object.Destroy(window.transform.gameObject);
        finishedAct();
    }
}