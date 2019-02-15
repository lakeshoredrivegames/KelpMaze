/* Swings the sword if the player has it in the inventory */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class UseItemCommand: Command
    {
        public override void Execute(PlayerManager player)
        {
            player.UseItem();
        }
    }
}
