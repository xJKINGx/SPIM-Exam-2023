using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Candidate number: 972
*/

public class RedState : IState
{
    private Material material;

    public RedState()
    {
         
    }
    public void Enter()
    {
        //Debug.Log("Entered Red State!");
    }

    public void Update()
    {

    }

    public void Exit()
    {
        //Debug.Log("Leaving Red State!");
    }
}
