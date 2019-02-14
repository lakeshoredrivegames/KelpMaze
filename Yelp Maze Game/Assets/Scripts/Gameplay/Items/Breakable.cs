using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace KelpMaze.Gameplay
{
    public class Breakable : MonoBehaviour
    {
        private void Start()
        {
            audio = this.gameObject.AddComponent<AudioSource>();
        }

        /* Got hit by something */
        public void Hit(PlayerManager player)
        {
            if(player.swordLevel >= minimumSwordLevel)
            {
                audio.clip = attackedClip;
                audio.Play();
                Health -= player.swordLevel;
                if (Health <= 0)
                    Broken(player);
            }
        }

        public void Broken(PlayerManager player)
        {
            audio.clip = brokenClip;
            audio.Play();
            Destroy(this.gameObject);
        }

        public int Health;
        public int minimumSwordLevel;
        public AudioClip attackedClip;
        public AudioClip brokenClip;
        public AudioSource audio;
    }
}
