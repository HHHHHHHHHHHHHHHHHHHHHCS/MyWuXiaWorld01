using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerCtrl : MonoBehaviour
{
    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.onActionTriggered += MoveCallback;
            playerInput.onActionTriggered += QWERCallback;
            playerInput.onActionTriggered += NumberCallback;
        }
    }

    private void MoveCallback(InputAction.CallbackContext ctx)
    {
        
        if (ctx.control == Mouse.current.leftButton)
        {
            Debug.Log(1);
        }
        else if (ctx.control == Mouse.current.rightButton)
        {
            Debug.Log(2);
        }
    }

    private void QWERCallback(InputAction.CallbackContext ctx)
    {
        if (ctx.control == Keyboard.current.qKey)
        {
            Debug.Log(1);
        }
        else if (ctx.control == Keyboard.current.wKey)
        {
            Debug.Log(1);
        }
        else if (ctx.control == Keyboard.current.eKey)
        {
            Debug.Log(1);
        }
        else if (ctx.control == Keyboard.current.rKey)
        {
            Debug.Log(1);
        }
    }

    private void NumberCallback(InputAction.CallbackContext ctx)
    {
        if (ctx.control == Keyboard.current.digit1Key)
        {
            Debug.Log(1);
        }
    }

}