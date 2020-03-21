using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMonoBase
{
    protected PlayerManager playerManager;


    public virtual void OnCtor(PlayerManager _pm)
    {
        playerManager = _pm;
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
