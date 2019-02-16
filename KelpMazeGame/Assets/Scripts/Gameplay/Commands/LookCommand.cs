/* Allows the player to look using mouse*/

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class LookCommand : Command
    {
        public LookCommand()
        {
            Controller = GameObject.Find("Player").GetComponent<FirstPersonController>();
        }

        public override void Execute(PlayerManager player)
        {
            Controller.MoveUpdate();
        }

        private FirstPersonController Controller;
    }
}