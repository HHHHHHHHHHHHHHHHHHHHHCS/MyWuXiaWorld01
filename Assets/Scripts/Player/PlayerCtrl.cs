﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.UI;

public class PlayerCtrl : PlayerMonoBase
{
    public static readonly Vector2 NullMousePosition = new Vector2(float.MinValue, float.MinValue);

    private bool movePress;

    private PlayerInput playerInput;

    private Vector2 mousePosition;

    public Vector2 MousePosition => mousePosition;

    public bool MovePress => movePress;

    public override void OnAwake()
    {
        playerInput = playerManager.GetComponent<PlayerInput>();

        playerInput.actions["Move"].performed += MoveCallback;
        playerInput.actions["QWER"].performed += QWERCallback;
        playerInput.actions["Number"].performed += NumberCallback;
    }

    public override void OnEnable()
    {
        playerInput.actions.Enable();
    }

    public override void OnDisable()
    {
        playerInput.actions.Disable();
    }

    public override void OnUpdate()
    {
        if (movePress && Mouse.current.leftButton.isPressed)
        {
            if (!MainUIManager.IsTouchUI)
            {
                mousePosition = Mouse.current.position.ReadValue();
            }
            else
            {
                mousePosition = NullMousePosition;
            }
        }
        else
        {
            mousePosition = NullMousePosition;
        }
    }

    private void MoveCallback(InputAction.CallbackContext ctx)
    {
        if (ctx.control == Mouse.current.leftButton)
        {
            if (ctx.interaction is PressInteraction interaction)
            {
                if (!MainUIManager.IsTouchUI)
                {
                    if (interaction.behavior == PressBehavior.PressOnly)
                    {
                        movePress = true;
                    }
                    else if (interaction.behavior == PressBehavior.ReleaseOnly)
                    {
                        movePress = false;
                    }
                }
                else
                {
                    movePress = false;
                }
            }
        }
        else if (ctx.control == Mouse.current.rightButton)
        {
            if (ctx.interaction is PressInteraction)
            {
            }
            else if (ctx.interaction is TapInteraction)
            {
            }
        }
    }

    private void QWERCallback(InputAction.CallbackContext ctx)
    {
        if (ctx.control == Keyboard.current.qKey)
        {
            Debug.Log('Q');
        }
        else if (ctx.control == Keyboard.current.wKey)
        {
            Debug.Log('W');
        }
        else if (ctx.control == Keyboard.current.eKey)
        {
            Debug.Log('E');
        }
        else if (ctx.control == Keyboard.current.rKey)
        {
            Debug.Log('R');
        }
    }

    private void NumberCallback(InputAction.CallbackContext ctx)
    {
        if (ctx.control == Keyboard.current.digit1Key)
        {
            Debug.Log(1);
        }
        else if (ctx.control == Keyboard.current.digit2Key)
        {
            Debug.Log(2);
        }
        else if (ctx.control == Keyboard.current.digit3Key)
        {
            Debug.Log(3);
        }
        else if (ctx.control == Keyboard.current.digit4Key)
        {
            Debug.Log(4);
        }
    }
}