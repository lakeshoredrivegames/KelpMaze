using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light lightToSwitch = null;

    void Start()
    {
        lightToSwitch.enabled = false;
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))        
        lightToSwitch.enabled = true;
    }
}
