using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class Conch : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Debug.Log(other.gameObject.name);
                PlayerManager manager = other.gameObject.GetComponentInChildren<PlayerManager>();
                if(!manager.hasConch)
                    manager.AddConchToInventory();
            }

        }
    }
}
