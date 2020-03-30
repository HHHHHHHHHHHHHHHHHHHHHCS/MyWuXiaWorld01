using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowMonoBase
{
    public Transform root;
    protected MainUIManager mainUIManager;

    public virtual void OnCtor(MainUIManager _uiManager, Transform _root) 
    {
        root = _root;
        mainUIManager = _uiManager;
        _root.SetParent(_uiManager.transform,false);
    }

    public virtual void OnAwake()
    {
    }

    public virtual void OnEnable()
    {
    }

    public virtual void OnDisable()
    {
    }

    public virtual void OnUpdate()
    {
    }
}