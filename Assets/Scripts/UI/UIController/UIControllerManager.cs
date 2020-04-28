public static class UIControllerManager
{
    public static T CreateController<T>(MainUIManager uiManager)
        where T : AbsUIControllerBase, new()
    {

        T ctrl = new T();
        ctrl.OnCtor(uiManager);
        ctrl.OnAwake();
        return ctrl;
    }
}