using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BearCollision : MonoBehaviour
{
    public GameObject nav,bear;
    public Animator bearfront, bearback, bearsideL, bearsideR;
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
        if (collision.gameObject.layer == 12)
        {
            bearback.SetBool("walk", false);
            bearsideL.SetBool("walk", false);
            bearsideR.SetBool("walk", false);
            bearfront.SetBool("walk", false);
            Debug.Log("envo");
            bear.GetComponent<BearPushPull>().envo = true;
            nav.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
}
