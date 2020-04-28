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

    public override void OnCtor(MainUIManager _mainUIManager, Transform _transform)
    {
        base.OnCtor(_mainUIManager, _transform);

        rayCastTransform = _transform.Find("TipsImage") as RectTransform;
    }

    public void UpdatePos(float x = 0, float y = 0, float width = 128, float height = 128)
    {
        rayCastTransform.localPosition = new Vector3(x, y, 0);
        rayCastTransform.sizeDelta = new Vector2(width, height);
        CreateBlock(rayCastTransform);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rect">pos and size default is vector4(0, 0, 128, 128)</param>
    public void UpdatePos(Rect rect)
    {
        rayCastTransform.localPosition = rect.position;
        rayCastTransform.sizeDelta = rect.size;
        CreateBlock(rayCastTransform);
    }

    private void CreateBlock(RectTransform tips)
    {
        if (block == null)
        {
            block = new RectTransform[4];
            for (int i = 0; i < 4; ++i)
            {
                var go = new GameObject("Block");
                go.transform.SetParent(transform, false);
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

        var screenSize = ((RectTransform) transform).rect.size;

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