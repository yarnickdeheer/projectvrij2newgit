using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BearTarget : MonoBehaviour
{
   public NavMeshAgent bear;
   public Animator bearfront, bearback, bearsideL, bearsideR;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            bearback.SetBool("walk", false);
            bearsideL.SetBool("walk", false);
            bearsideR.SetBool("walk", false);
            bearfront.SetBool("walk", false);
            bear.speed = 0;
        }
    }
}




//public Transform[] patrolPoints; // An Array of path points to be followed
//private int currentPoint;
//public float enemySpeed;

//void Start()
//{

//    currentPoint = 0;
//    transform.position = patrolPoints[currentPoint].position; // Starting Point
//}

//void Update()
//{

//    if (transform.position == patrolPoints[currentPoint].position)
//    {
//        currentPoint++;
//    }


//    if (currentPoint >= patrolPoints.Length)
//    {
//        currentPoint = 0;
//    }

//    transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, enemySpeed * Time.deltaTime);

//}
