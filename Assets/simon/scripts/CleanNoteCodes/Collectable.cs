using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    CollectableManager collectableManager;
    // Start is called before the first frame update
    void Start()
    {
        collectableManager = FindObjectOfType<CollectableManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            collectableManager.collectedSheets++;
            Destroy(this.gameObject);
        }
    }
}
