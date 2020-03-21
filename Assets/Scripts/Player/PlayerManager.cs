using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private PlayerBehaviour playerBehaviour;
    private PlayerAnim playerAnim;

    private Action OnAwakeActions;
    private Action OnEnableActions;
    private Action OnDisableActions;
    private Action OnUpdateActions;

    public PlayerCtrl PlayerCtrl => playerCtrl;
    public PlayerBehaviour PlayerBehaviour => playerBehaviour;
    public PlayerAnim PlayerAnim => playerAnim;

    private T RegisterMono<T>(PlayerManager _pm) where T : PlayerMonoBase, new()
    {
        T t = new T();

        t.OnCtor(_pm);

        OnAwakeActions += t.OnAwake;
        OnEnableActions += t.OnEnable;
        OnDisableActions += t.OnDisable;
        OnUpdateActions += t.OnUpdate;

        return t;
    }


    public void Awake()
    {
        playerCtrl = RegisterMono<PlayerCtrl>(this);
        playerBehaviour = RegisterMono<PlayerBehaviour>(this);
        playerAnim = RegisterMono<PlayerAnim>(this);

        OnAwakeActions?.Invoke();
    }

    private void OnEnable()
    {
        OnEnableActions?.Invoke();
    }

    private void OnDisable()
    {
        OnDisableActions?.Invoke();
    }

    private void Update()
    {
        OnUpdateActions?.Invoke();
    }
}