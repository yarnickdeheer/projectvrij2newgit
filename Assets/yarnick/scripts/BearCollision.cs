using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BearCollision : MonoBehaviour
{
    public GameObject nav,bear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enviroment")
        {
            Debug.Log("basinga");
            bear.GetComponent<BearPushPull>().envo = true;
            nav.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
}
