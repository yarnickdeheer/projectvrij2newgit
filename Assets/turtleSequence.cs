using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleSequence : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //start turtle sequence
        }
    }
}
