using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BearTarget : MonoBehaviour
{
   [HideInInspector] public NavMeshAgent bear;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            bear.speed = 0;
        }
    }
}
