using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;

/// <summary>
/// player state
/// </summary>
public enum Player1State
{
    Idle,
    Move,
    Attack,
    BeAttack,
    Dead
}

/// <summary>
/// player controller
/// </summary>
public class PlayerController : SingletonMono<PlayerController>,IStateMachineOwner
{
    public Animator animator;
    public CharacterController characterController;
    private StateMachine stateMachine;

    public Transform player1Transform { get; private set; }

    public void Init()
    {
        player1Transform = transform;

        stateMachine = ResManager.Load<StateMachine>();
        stateMachine.Init(this);
        //initial state: Idle
        stateMachine.ChangeState<PlayerIdle>((int)Player1State.Idle);
    }
}
