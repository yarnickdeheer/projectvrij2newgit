using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            StartCoroutine(wait());
            //this.gameObject.tag = "ground";
            //rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
    IEnumerator wait()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(2);
        this.gameObject.tag = "ground";
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}
