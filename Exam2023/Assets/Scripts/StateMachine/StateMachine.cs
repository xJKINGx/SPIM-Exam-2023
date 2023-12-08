using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Candidate number: 972
*/

[Serializable]
public class StateMachine : MonoBehaviour
{
    public IState currentState { get; private set; }

    public RedState redState;
    public GreenState greenState;

    public StateMachine()
    {
        this.redState = new RedState();
        this.greenState = new GreenState();
    }

    public void Initialize(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
