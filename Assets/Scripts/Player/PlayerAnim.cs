using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : PlayerMonoBase
{
    private Animator animator;
    private PlayerBehaviour playerBehaviour;

    private int xSpeedID = Animator.StringToHash("xSpeed");
    private int ySpeedID = Animator.StringToHash("ySpeed");
    private int haveInputID = Animator.StringToHash("haveInput");
    private int moveDirID = Animator.StringToHash("moveDir");


    public override void OnAwake()
    {
        animator = playerManager.GetComponent<Animator>();
        playerBehaviour = playerManager.PlayerBehaviour;
    }

    public override void OnUpdate()
    {
        animator.SetFloat(xSpeedID, playerBehaviour.OffsetPos.x);
        animator.SetFloat(ySpeedID, playerBehaviour.OffsetPos.y);
        if (!playerBehaviour.HaveInput)
        {
            animator.SetInteger(moveDirID, (int)playerBehaviour.MoveDir);
        }
        animator.SetBool(haveInputID, playerBehaviour.HaveInput);
    }
}