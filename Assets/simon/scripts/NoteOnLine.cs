using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOnLine : MonoBehaviour
{
    public Transform endpos;
    private float veci;
    // Start is called before the first frame update
    void Start()
    {
        veci = transform.position.x + 900;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * 300, 0, 0);

        if(transform.position.x > veci )
        {
            Destroy(this.gameObject);
        }
    }
}
