using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikedDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Spiked();
        }

    }

    // Update is called once per frame
    void Spiked()
    {
        SceneManager.LoadScene("SpikedDeath");
    }
        
    
}
