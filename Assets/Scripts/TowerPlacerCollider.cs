using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collision detected with trigger object " + other.name);
    }

    void OnTriggerExit(Collider other)
    {
        print(gameObject.name + " and trigger object " + other.name + " are no longer colliding");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
