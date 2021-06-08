using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSoundMover : MonoBehaviour
{
    Vector3 startPos;
    float plusXLim, minXLim, plusZLim, minZLim;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = transform.position;
        plusXLim = startPos.x + 4;
        minXLim = startPos.x - 3;
        plusZLim = startPos.z + 23;
        minZLim = startPos.z - 20;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosIn2D = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPosIn2D, 1f);

        if (transform.position.x < minXLim)
        {
            transform.position = new Vector3(minXLim, transform.position.y, transform.position.z);
        }

        if (transform.position.x > plusXLim)
        {
            transform.position = new Vector3(plusXLim, transform.position.y, transform.position.z);
        }

        if(transform.position.z < minZLim)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZLim);
        }

        if (transform.position.z > plusZLim)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, plusZLim);
        }
    }
}
