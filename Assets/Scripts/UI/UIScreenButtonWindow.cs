using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenButtonWindow : UIWindowMonoBase
{
    private Sprite defaultSprite;
    private Button nextButton;
    private Text nextText;
    private Button jumpButton;
    private Text jumpText;


    public override void OnCtor(MainUIManager _uiManager, Transform _root)
    {
        base.OnCtor(_uiManager, _root);
        nextButton = root.Find("NextButton").GetComponent<Button>();
        nextText = nextButton.transform.Find("NextText").GetComponent<Text>();
        jumpButton = nextButton.transform.Find("JumpButton").GetComponent<Button>();
        nextText = jumpButton.transform.Find("JumpText").GetComponent<Text>();

        defaultSprite = nextButton.image.sprite;
    }

    public void SetImageAndText(string imagePath = null, string text = null)
    {
        if (string.IsNullOrEmpty(imagePath))
        {

        }

        if (string.IsNullOrEmpty(text))
        {

        }
    }

    public void ClearImageAndText(bool image = true, bool text = true)
    {
        if (image)
            nextButton.image.sprite = defaultSprite;
        if (text)
            nextText.text = string.Empty;
    }

    public void ShowJump()
    {
        jumpButton.transform.localScale = Vector3.zero;
    }

    public void HideJump()
    {
        jumpButton.transform.localScale = Vector3.zero;
    }
}