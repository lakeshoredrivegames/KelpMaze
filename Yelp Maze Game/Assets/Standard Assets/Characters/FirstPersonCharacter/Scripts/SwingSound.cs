using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SwingSound : MonoBehaviour
{     
    private AudioSource audioSource;

   void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
            {
           audioSource.PlayDelayed(1/2);
            }
    }
}
