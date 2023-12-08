using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Timeline.Actions;
using UnityEngine;

/*
    Candidate number: 972
*/

public class TrafficLight : MonoBehaviour
{
    [SerializeField] StateMachine stateMachine;
    [SerializeField] float LightDuration = 6.0f;

    [SerializeField] List<Material> materials;

    public bool bStop = true;
    private MeshRenderer mesh;    

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        if (stateMachine != null)
        {
            stateMachine.Initialize(stateMachine.redState);
            InvokeRepeating("ChangeLight", LightDuration, LightDuration);
        }
    }

    void ChangeLight()
    {
        if (stateMachine.currentState == stateMachine.redState)
        {
            stateMachine.TransitionTo(stateMachine.greenState);
            mesh.material = materials[1];
            bStop = false;
        }
        else 
        {
            stateMachine.TransitionTo(stateMachine.redState);
            mesh.material = materials[0];
            bStop = true;
        }
    }
}
