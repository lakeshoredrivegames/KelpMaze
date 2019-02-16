/* Handles controls for the player */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    /*! \brief Handles simulated input */
    public class InputHandler : MonoBehaviour
    {
        private void Start()
        {
            worldManager = GameObject.Find("WorldManager").GetComponent<WorldManager>();
            playerManager = this.gameObject.GetComponentInParent<PlayerManager>();

            move = new MoveCommand();
            look = new LookCommand();
            useItem = new UseItemCommand();
            swapItem = new SwapItemCommand();
        }

        private void Update()
        {
            if(!worldManager.IsPaused)
            {
                Command cmd = this.HandleInput();
                if (cmd != null) cmd.Execute(playerManager);
            }
            if(Input.GetKeyDown(KeyCode.Escape)) { worldManager.PauseGame(); }
        }

        private void FixedUpdate()
        {
            if(!worldManager.IsPaused)
            {
                Command cmd = this.FixedHandleInput();
                if (cmd != null) cmd.Execute(playerManager);
            }
        }

        public Command HandleInput()
        {
            if(Input.GetButtonDown("Fire1")) { return useItem; }
            if(Input.GetKeyDown(KeyCode.E)) { return swapItem; }
            return look;
        }

        public Command FixedHandleInput()
        {
            return move;
        }

        private WorldManager worldManager;
        private PlayerManager playerManager;

        private MoveCommand move;
        private LookCommand look;
        private UseItemCommand useItem;
        private SwapItemCommand swapItem;
    }
} /* KelpMaze.Gameplay */
