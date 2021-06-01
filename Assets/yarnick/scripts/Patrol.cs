// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform target;
    private int destPoint = 0;
    private NavMeshAgent agent;

    //public GameObject DB;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
    
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
  

        // Set the agent to go to the currently selected destination.
        agent.destination = new Vector3(target.position.x, target.position.y, target.position.z);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
    }


    void Update()
    {
   

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    
        GotoNextPoint();
    }

    

}