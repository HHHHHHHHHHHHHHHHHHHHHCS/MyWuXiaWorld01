using UnityEngine;

public class AbsUIControllerBase
{
    public MainUIManager mainUIManager;

    public virtual void OnCtor(MainUIManager _mainUIManager)
    {
        mainUIManager = _mainUIManager;
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