using UnityEngine;

public class StartUIFlowStep
{
    private static StartUIFlowStep _instance;

    public static StartUIFlowStep Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StartUIFlowStep();
            }

            return _instance;
        }
    }

    #region StartUIFlowController

    private StartUIFlowController startUIFlow;

    public StartUIFlowController StartUIFlow
    {
        get
        {
            CreateStartUIFlowController();
            return startUIFlow;
        }

        set => startUIFlow = value;
    }

    public void CreateStartUIFlowController()
    {
        if (startUIFlow == null)
        {
            startUIFlow = UIControllerManager.CreateController<StartUIFlowController>(MainUIManager.Instance);
            startUIFlow.Init(CreateStartMoveTipsFlowController);
            startUIFlow.OnShow();
        }
    }

    #endregion

    #region StartMoveTipsFlowController

    private StartMoveTipsFlowController startMoveTipsFlow;

    public StartMoveTipsFlowController StartMoveTipsFlow
    {
        get
        {
            CreateStartMoveTipsFlowController();
            return startMoveTipsFlow;
        }
        set => startMoveTipsFlow = value;
    }

    public void CreateStartMoveTipsFlowController()
    {
        if (startMoveTipsFlow == null)
        {
            UIControllerManager.RemoveController(MainUIManager.Instance, StartUIFlow);
            StartUIFlow = null;
            startMoveTipsFlow =
                UIControllerManager.CreateController<StartMoveTipsFlowController>(MainUIManager.Instance);
            startMoveTipsFlow.OnInit( );
            startMoveTipsFlow.OnShow();
        }
    }



    #endregion
}