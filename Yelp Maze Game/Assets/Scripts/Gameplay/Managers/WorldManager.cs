/* Acts as a GameManager */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

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

        public bool IsPaused;
    }
}
