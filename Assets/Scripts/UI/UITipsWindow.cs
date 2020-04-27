using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITipsWindow : UIWindowMonoBase
{
    protected static bool isInit;

    public RectTransform rayCastTransform;

    public RectTransform[] block;

    public static void Create(MainUIManager uiManager, Action<UITipsWindow> act)
    {
        if (!isInit)
        {
            isInit = true;
            UIWindowManager.windowDictionary.Add(typeof(UITipsWindow),
                UIWindowManager.uiWindowData.tipsWindowAsset);
        }

        UIWindowManager.CreateWindow(uiManager, act);
    }

    public override void OnCtor(MainUIManager _uiManager, Transform _root)
    {
        base.OnCtor(_uiManager, _root);

        rayCastTransform = _root.Find("TipsImage") as RectTransform;
        CreateBlock(rayCastTransform);
    }

    public void CreateBlock(RectTransform tips)
    {
        if (block == null)
        {
            block = new RectTransform[4];
            for (int i = 0; i < 4; ++i)
            {
                var go = new GameObject("Block");
                go.transform.SetParent(root, false);
                go.AddComponent<UIEmptyRayCast>();
                block[i] = go.transform as RectTransform;
            }
        }

        var sizeDelta = tips.sizeDelta;
        var localPosition = tips.localPosition;
        float left = localPosition.x - sizeDelta.x / 2.0f;
        float right = localPosition.x + sizeDelta.x / 2.0f;
        float bottom = localPosition.y - sizeDelta.y / 2.0f;
        float up = localPosition.y + sizeDelta.y / 2.0f;

        var screenSize = ((RectTransform) root).rect.size;

        float rb = screenSize.x / 2;
        float lb = -rb;
        float ub = screenSize.y / 2;
        float bb = -ub;

        block[0].localPosition = new Vector2((left + lb) / 2, (bottom + ub) / 2);
        block[0].sizeDelta = new Vector2(left - lb, ub - bottom);

        block[1].localPosition = new Vector2((left + rb) / 2, (up + ub) / 2);
        block[1].sizeDelta = new Vector2(rb - left, ub - up);

        block[2].localPosition = new Vector2((rb + right) / 2, (up + bb) / 2);
        block[2].sizeDelta = new Vector2(rb - right, up - bb);

        block[3].localPosition = new Vector2((lb + right) / 2, (bottom + bb) / 2);
        block[3].sizeDelta = new Vector2(right - lb, bottom - bb);
    }
}