using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager
{
    private static Camera _mainCamera;

    public static Camera MainCamera
    {
        get
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }

            return _mainCamera;
        }
    }

    public static Transform transform => MainCamera.transform;

    public static Vector3 position => MainCamera.transform.position;
}
