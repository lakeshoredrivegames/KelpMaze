using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winGame();
        }

    }

    // Update is called once per frame
    void winGame()
    {
        SceneManager.LoadScene(3);
    }
}
