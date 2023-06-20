using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;


/// <summary>
/// player state base
/// Abstract the common fields and functions required by all player states
/// </summary>
public class PlayerStateBase : StateBase
{
    protected PlayerController player1;
    

    public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
    {
        base.Init(owner, stateType, stateMachine);
        player1 = owner as PlayerController;
    }

    /// <summary>
    /// play animation
    /// </summary>
    protected void PlayAnimation(string animationName, float fixedTime = 0.25f)
    {
        player1.animator.CrossFadeInFixedTime(animationName, fixedTime);
    }

    /// <summary>
    /// Change state
    /// </summary>
    protected void ChangeState(Player1State player1State)
    {
        switch (player1State)
        {
            case Player1State.Idle:
                stateMachine.ChangeState<PlayerIdle>(0);
                break;
            case Player1State.Move:
                stateMachine.ChangeState<PlayerMove>(1);
                break;
            case Player1State.Attack:
                break;
            case Player1State.BeAttack:
                break;
            case Player1State.Dead:
                break;
        }
        
    }
}
