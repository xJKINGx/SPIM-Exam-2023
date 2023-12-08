using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
    Candidate number: 972
*/

public class GoalObserver : MonoBehaviour
{
    [SerializeField] TMP_Text lapsText;
    [SerializeField] GoalSubject targetToListenTo;

    private int laps = 0;

    void OnGoalReached()
    {
        ChangeLapsText(laps++);
    }

    private void Awake() 
    {
        if (targetToListenTo != null)
        {
            targetToListenTo.lapsOccurence += OnGoalReached;
        }    
    }

    void ChangeLapsText(int value)
    {
        lapsText.text = "Laps: " + value;
    }

    private void OnDestroy() 
    {
        if (targetToListenTo != null)
        {
            targetToListenTo.lapsOccurence -= OnGoalReached;
        }    
    }
}
