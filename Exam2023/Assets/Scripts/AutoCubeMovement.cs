using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

/*
    Candidate number: 972
*/

public class AutoCubeMovement : MonoBehaviour
{
    SplineAnimate splineAnimate;

    bool bIsInTrigger = false;

    private TrafficLight currentTrafficLight;
    private void Start() 
    {
        splineAnimate = GetComponent<SplineAnimate>();
    }

    private void Update() 
    {
        if (bIsInTrigger)
        {
            if (CanMove())
            {
                splineAnimate.Play();
            }
            else
            {
                splineAnimate.Pause();
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "TrafficLight")
        {
            currentTrafficLight = other.GetComponent<TrafficLight>();
            bIsInTrigger = true;
            if (CanMove())
            {
                splineAnimate.Play();
            }
            else
            {
                splineAnimate.Pause();
            }
        }    
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "TrafficLight")
        {
            bIsInTrigger = false;
            currentTrafficLight = null;
        }
    }

    private bool CanMove()
    {
        if (currentTrafficLight != null)
        {
            if (currentTrafficLight.bStop) { return false; }
            else { return true; }
        }
        return false;
    }
}
