using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Candidate number: 972
*/

public class GoalSubject : MonoBehaviour
{
    public event Action lapsOccurence;

    public void SendLapsMessage()
    {
        lapsOccurence?.Invoke();
        //Debug.Log("Message sent");
    }
}
