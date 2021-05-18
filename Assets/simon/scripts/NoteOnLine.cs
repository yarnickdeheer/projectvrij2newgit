using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOnLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * 300, 0, 0);

        if(transform.position.x > Screen.width)
        {
            Destroy(this.gameObject);
        }
    }
}
