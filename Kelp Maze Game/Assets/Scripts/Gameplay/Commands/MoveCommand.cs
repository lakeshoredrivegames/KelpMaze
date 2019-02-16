/* Allows the player to move using movement keys */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class MoveCommand : Command
    {
        public MoveCommand()
        {
            Controller = GameObject.Find("Player").GetComponent<FirstPersonController>(); 
        }

        public override void Execute(PlayerManager player)
        {
            Controller.MoveFixedUpdate();
        }

        private FirstPersonController Controller;
    }
}
