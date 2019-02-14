/* Swaps the item in the players inventory */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class SwapItemCommand: Command
    {
        public override void Execute(PlayerManager player)
        {
            player.SwapItem();
        }
    }
}
