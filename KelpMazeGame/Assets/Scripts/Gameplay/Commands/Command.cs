/* Abstract commands */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;


namespace KelpMaze.Gameplay
{
    /*! \brief Abstract commands
     * 
     * Each command in the game is derived
     * from this command class. This class
     * stubs an execute method that is used
     * for any "action" that the player can
     * perform in the game.
     */
    public class Command
    {
        /* Executes an artibrary action */
        public virtual void Execute(PlayerManager player) { }
    }
} /* KelpMaze.Gameplay */