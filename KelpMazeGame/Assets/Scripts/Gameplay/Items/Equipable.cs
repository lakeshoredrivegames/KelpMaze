/* Items that can be picked up by the player */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class Equipable
    {
        public virtual void Execute(PlayerManager player) {}
    }
}
