using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

/*
    Candidate number: 972
*/

public class Movement : MonoBehaviour
{
    private float maxSpeed = 0.3f;
    private float minSpeed = 0.05f;
    private float acceleration = 0.10f;

    private float speed = 0.0f;
    private SplineAnimate splineAnimate;
    private SplineContainer splineContainer;

    float splineLength;
    float travelPercentage;

    void Start()
    {
        speed = minSpeed; 
        splineAnimate = GetComponent<SplineAnimate>();
        splineContainer = splineAnimate.Container;
        splineLength = splineContainer.CalculateLength();

    }
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            speed -= acceleration * Time.deltaTime;   
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            speed += acceleration * Time.deltaTime;
        }

        speed = speed > maxSpeed ? maxSpeed : speed;
        speed = speed < minSpeed ? minSpeed : speed; 
        
        travelPercentage += speed / splineLength;
        Vector3 CurrentPos = splineContainer.EvaluatePosition(travelPercentage);
        transform.position = CurrentPos;

        if (travelPercentage > 1.0f)
        {
            travelPercentage = 0.0f;
        }

        Debug.Log("Player's speed: " + speed + "m/s");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Finish")
        {
            other.GetComponent<GoalSubject>().SendLapsMessage();    
        }    
    }
}
