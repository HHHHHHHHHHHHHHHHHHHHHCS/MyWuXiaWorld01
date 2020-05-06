public static class UIFlowStep
{
    private static StartUIFlowController startUIFlow;

    public static StartUIFlowController StartUIFlow
    {
        get
        {
            CreateStartUIFlowController();
            return startUIFlow;
        }
        set => startUIFlow = value;
    }

    public static void CreateStartUIFlowController()
    {
        if (startUIFlow == null)
        {
            startUIFlow = UIControllerManager.CreateController<StartUIFlowController>(MainUIManager.Instance);
            startUIFlow.Show(CreateStartMoveTipsFlowController);
        }
    }

    private static StartMoveTipsFlowController startMoveTipsFlow;

    public static StartMoveTipsFlowController StartMoveTipsFlow
    {
        get
        {
            CreateStartMoveTipsFlowController();
            return startMoveTipsFlow;
        }
        set => startMoveTipsFlow = value;
    }

    public static void CreateStartMoveTipsFlowController()
    {
        if (startMoveTipsFlow == null)
        {
            StartUIFlow = null;
            startMoveTipsFlow = UIControllerManager.CreateController<StartMoveTipsFlowController>(MainUIManager.Instance);
            startMoveTipsFlow.Show(null);
        }
    }
}