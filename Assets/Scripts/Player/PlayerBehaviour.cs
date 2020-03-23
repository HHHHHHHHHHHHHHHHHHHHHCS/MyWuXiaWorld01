using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : PlayerMonoBase
{
    public enum MoveDirection
    {
        Forward = 0,
        Back,
        Left,
        Right
    }

    private Camera mainCamera;
    private float zOffset;

    private Vector2 offsetPos;
    private bool haveInput;
    private MoveDirection moveDir = MoveDirection.Right;
    private Rigidbody2D rigi2D;


    public Vector2 OffsetPos => offsetPos;
    public bool HaveInput => haveInput;
    public MoveDirection MoveDir => moveDir;

    public override void OnAwake()
    {
        rigi2D = playerManager.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        zOffset = mainCamera.transform.position.z - playerManager.transform.position.z;
    }

    public override void OnUpdate()
    {
        var scrPos = playerManager.PlayerCtrl.MousePosition;
        if (scrPos != PlayerCtrl.NullMousePosition)
        {
            var inputPos = mainCamera.ScreenToWorldPoint(scrPos);
            var playerPos = playerManager.transform.position;
            inputPos.z += zOffset;
            offsetPos = inputPos - playerPos;

            if (offsetPos.sqrMagnitude > 0.01f)
            {
                haveInput = true;
                moveDir = GetMoveDirection(offsetPos);
                rigi2D.velocity = offsetPos.normalized * playerManager.PlayerInfo.moveSpeed;
            }
            else
            {
                haveInput = false;
                offsetPos = Vector2.zero;
                rigi2D.velocity = Vector2.zero;
            }
        }
        else
        {
            haveInput = false;
            offsetPos = Vector2.zero;
            rigi2D.velocity = Vector2.zero;
        }
    }

    public static MoveDirection GetMoveDirection(Vector2 v2)
    {
        MoveDirection dir = MoveDirection.Forward;


        if (v2.x == v2.y && v2.y == 0)
        {
            return dir;
        }

        var x = Mathf.Abs(v2.x);
        var y = Mathf.Abs(v2.y);

        if (x >= y)
        {
            if (v2.x > 0)
            {
                dir = MoveDirection.Right;
            }
            else if (v2.x < 0)
            {
                dir = MoveDirection.Left;
            }
        }
        else if (x < y)
        {
            if (v2.y > 0)
            {
                dir = MoveDirection.Forward;
            }
            else if (v2.y < 0)
            {
                dir = MoveDirection.Back;
            }
        }

        return dir;
    }
}