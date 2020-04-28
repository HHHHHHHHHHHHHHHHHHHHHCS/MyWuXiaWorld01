using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UITalkWindow : UIWindowMonoBase
{
    protected static bool isInit;

    private Button prefab_ClickButton;
    private Text nameText;
    private Text contextText;
    private Transform rightBar;

    private List<Button> clickButtonList;

    public List<Button> ClickButtonList => clickButtonList;

    public static void Create(MainUIManager uiManager, Action<UITalkWindow> act)
    {
        if (!isInit)
        {
            isInit = true;
            UIWindowManager.windowDictionary.Add(typeof(UITalkWindow),
                UIWindowManager.uiWindowData.talkWindowAsset);
        }

        UIWindowManager.CreateWindow(uiManager, act);
    }

    public override void OnCtor(MainUIManager _mainUIManager, Transform _transform)
    {
        base.OnCtor(_mainUIManager, _transform);
        prefab_ClickButton = transform.Find("Prefab_ClickButton").GetComponent<Button>();
        nameText = transform.Find("BottomBar/NamText").GetComponent<Text>();
        contextText = transform.Find("BottomBar/ContextText").GetComponent<Text>();
        rightBar = transform.Find("RightBar");
        clickButtonList = new List<Button>();
    }

    public void SetNameContext(string name, string context, bool needColon = true)
    {
        if (needColon)
        {
            nameText.text = name + ":";
        }
        else
        {
            nameText.text = name;
        }

        contextText.text = context;
    }

    public Button AddClickButton(string btnName, UnityAction act)
    {
        Button btn = Object.Instantiate(prefab_ClickButton, rightBar);
        var btnText = btn.transform.Find("BtnText").GetComponent<Text>();
        btnText.text = btnName;
        btn.onClick.AddListener(act);
        clickButtonList.Add(btn);
        btn.gameObject.SetActive(true);
        return btn;
    }

    public bool RemoveButton(int index)
    {
        if (index < 0 || index > clickButtonList.Count)
        {
            return false;
        }

        var btn = clickButtonList[index];
        clickButtonList.RemoveAt(index);
        Object.Destroy(btn);
        return true;
    }

    public bool RemoveButton(Button btn)
    {
        return RemoveButton(clickButtonList.IndexOf(btn));
    }

    public void RemoveAllButton()
    {
        for (int i = clickButtonList.Count - 1; i >= 0; i--)
        {
            RemoveButton(i);
        }
    }

    public void Close()
    {
        Object.Destroy(transform.gameObject);
    }
}