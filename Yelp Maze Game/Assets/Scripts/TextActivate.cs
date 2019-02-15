using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivate : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMesh textMesh;
    void Start()
    {
        textMesh = this.gameObject.GetComponent<TextMesh>();
        textMesh.gameObject.SetActive(false);

    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))        
        textMesh.gameObject.SetActive(true);
    }

    public void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))        
        textMesh.gameObject.SetActive(false);
    }
}
