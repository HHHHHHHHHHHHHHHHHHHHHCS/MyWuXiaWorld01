using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIScreenButtonWindow : UIWindowMonoBase
{
    protected static bool isInit;

    public Sprite defaultSprite;
    public Button nextButton;
    public Text nextText;
    public Button jumpButton;
    public Text jumpText;

    public static void Create(MainUIManager uiManager, Action<UIScreenButtonWindow> act)
    {
        if (!isInit)
        {
            isInit = true;
            UIWindowManager.windowDictionary.Add(typeof(UIScreenButtonWindow),
                UIWindowManager.uiWindowData.screenButtonWindowAsset);
        }

        UIWindowManager.CreateWindow(uiManager, act);
    }

    public override void OnCtor(MainUIManager _mainUIManager, Transform _transform)
    {
        base.OnCtor(_mainUIManager, _transform);
        nextButton = transform.Find("NextButton").GetComponent<Button>();
        nextText = nextButton.transform.Find("NextText").GetComponent<Text>();
        jumpButton = transform.Find("JumpButton").GetComponent<Button>();
        jumpText = jumpButton.transform.Find("JumpText").GetComponent<Text>();

        defaultSprite = nextButton.image.sprite;
    }

    public void SetImageAndText(string imagePath = null, string text = null)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            nextButton.image.color = Color.white;
            AddressManager.LoadAndRelease<Sprite>(imagePath, x => nextButton.image.sprite = x);
        }
        else
        {
            nextButton.image.color = Color.gray;
            nextButton.image.sprite = defaultSprite;
        }

        if (!string.IsNullOrEmpty(text))
        {
            nextText.text = text;
        }
        else
        {
            nextText.text = string.Empty;
        }
    }

    public void ClearImageAndText(bool image = true, bool text = true)
    {
        if (image)
        {
            nextButton.image.color = Color.gray;
            nextButton.image.sprite = defaultSprite;
        }

        if (text)
        {
            nextText.text = string.Empty;
        }
    }

    public void ShowJump()
    {
        jumpButton.transform.localScale = Vector3.zero;
    }

    public void HideJump()
    {
        jumpButton.transform.localScale = Vector3.zero;
    }

    public void SetNextButtonEvent(UnityAction act)
    {
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(act);
    }
}