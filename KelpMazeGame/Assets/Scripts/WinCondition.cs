using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KelpMaze.Gameplay
{
    public class WinCondition : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                winGame();
                Timer timer = GameObject.Find("WorldManager").GetComponent<Timer>();
                PlayerPrefs.SetFloat("lastPlayTime", timer.currentTime);
            }

        }

        // Update is called once per frame
        void winGame()
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
