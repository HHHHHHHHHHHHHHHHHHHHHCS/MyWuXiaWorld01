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

    public virtual void OnShow()
    {
    }

    public virtual void OnHide()
    {
    }

    public virtual void OnUpdate(float deltaTime)
    {
    }
}