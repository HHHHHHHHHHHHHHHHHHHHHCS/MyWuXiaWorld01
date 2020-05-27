public static class UIControllerManager
{
    public static T CreateController<T>(MainUIManager uiManager)
        where T : AbsUIControllerBase, new()
    {
        T ctrl = new T();
        if (uiManager != null)
        {
            uiManager.uiControllerList.Add(ctrl);
        }

        ctrl.OnCtor(uiManager);
        ctrl.OnAwake();


        return ctrl;
    }

    public static bool RemoveController<T>(MainUIManager uiManager, T ctrl)
        where T : AbsUIControllerBase, new()
    {
        if (uiManager != null && ctrl != null)
        {
            return uiManager.uiControllerList.Remove(ctrl);
        }

        return true;
    }
}