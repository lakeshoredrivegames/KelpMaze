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
            timer = this.gameObject.GetComponent<Timer>();
            timer.isTiming = true;
        }

        public void PauseGame()
        {
            if(!IsPaused)
            {
                timer.isTiming = false;
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
                timer.isTiming = true;
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
        private Timer timer;
    }
}
