using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowMonoBase
{
    public Transform transform;
    protected MainUIManager mainUIManager;

    public virtual void OnCtor(MainUIManager _mainUIManager, Transform _transform) 
    {
        transform = _transform;
        mainUIManager = _mainUIManager;
        _transform.SetParent(_mainUIManager.transform,false);
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