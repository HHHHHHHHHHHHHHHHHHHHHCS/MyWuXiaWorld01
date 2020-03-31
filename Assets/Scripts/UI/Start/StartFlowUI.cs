using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlowUI : UIWindowMonoBase
{
    private UIScreenButtonWindow window;


    public override void OnAwake()
    {
        UIScreenButtonWindow.Create(mainUIManager, ShowWindow);
    }

    public void ShowWindow(UIScreenButtonWindow _window)
    {
        window = _window;
        window.SetImageAndText(null, "又能偷看李妮子洗澡了,嘿嘿嘿!");
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
        Object.Destroy(window.root.gameObject);
    }
}