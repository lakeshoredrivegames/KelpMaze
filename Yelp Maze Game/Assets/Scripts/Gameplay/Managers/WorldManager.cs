/* Acts as a GameManager */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;
using UnityEngine.UI;

namespace KelpMaze.Gameplay
{
    /* \brief Manages the players actions */
    public class WorldManager : MonoBehaviour
    {
        /* On instantiation */
        public void Start()
        {
            IsPaused = false;
        }

        public void PauseGame()
        {
            if(!IsPaused)
            {
                Cursor.visible = true;
                PauseText.enabled = true;
                RestartButton.gameObject.SetActive(true);
                RestartButton.enabled = true;
                QuitButton.gameObject.SetActive(true);
                QuitButton.enabled = true;
                IsPaused = true;
            }
            else
            {
                Cursor.visible = false;
                PauseText.enabled = false;
                RestartButton.gameObject.SetActive(false);
                RestartButton.enabled = false;
                QuitButton.gameObject.SetActive(false);
                QuitButton.enabled = false;
                IsPaused = false;
            }
        }

        public Text PauseText;
        public Button RestartButton;
        public Button QuitButton;

        public bool IsPaused;
    }
}
