using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;

/// <summary>
/// player1 idle state
/// </summary>
public class PlayerIdle : PlayerStateBase
{
    public override void Enter()
    {
        PlayAnimation("Idle");

    }

    public override void Update()
    {
        //If the player clicks any moving button, switch to the Move status

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != -2)
        {
            ChangeState(Player1State.Move);
        }
    }
}
