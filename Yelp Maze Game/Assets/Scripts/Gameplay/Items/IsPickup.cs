using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
            this.gameObject.SetActive(false);
    }
}
