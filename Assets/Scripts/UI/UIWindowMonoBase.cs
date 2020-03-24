using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowMonoBase
{
    protected MainUIManager mainUIManager;


    public virtual void OnCtor(MainUIManager _uiManager)
    {
        mainUIManager = _uiManager;
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
