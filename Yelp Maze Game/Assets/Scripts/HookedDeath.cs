using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookedDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Hooked();
        }

    }

    // Update is called once per frame
    void Hooked()
    {
        SceneManager.LoadScene("HookedDeath");
    }
        
    
}
