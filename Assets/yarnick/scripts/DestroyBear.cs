using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DestroyBear : MonoBehaviour
{
    [HideInInspector] public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist < 2)
        {
            Destroy(target);
            this.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
}
