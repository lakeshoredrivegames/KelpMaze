using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class ConchItem : Equipable
    {
        public ConchItem()
        {
           noClips = new List<AudioClip>();
            isCooling = false;
        }
        public override void Execute(PlayerManager player)
        {
            if(!isGlobalCooling)
            {
                if(isCooling)
                {
                    noClips.Add(player.useConchClipNo);
                    noClips.Add(player.useConchClipMaybe);
                    int r = Random.Range(0, 2);
                    player.audio.clip = noClips[r];
                    player.audio.Play();
                    if(Time.time >= conchCooldownTime)
                    {
                        isCooling = false;
                    }
                }
                else
                {
                    Debug.Log("Playing the conch!");
                    player.audio.clip = player.useConchClipYes;
                    player.audio.Play();
                    isCooling = true;
                    conchCooldownTime = Time.time + conchCooldown;
                }

                isGlobalCooling = true;
                globalCooldownTime = Time.time + globalConchCooldown;
            }
            else
            {
                if (Time.time >= globalCooldownTime)
                {
                    isGlobalCooling = false;
                }
            }
        }

        private List<AudioClip> noClips;
        private float conchCooldown = 5f;
        private bool isCooling;
        private float conchCooldownTime;

        private float globalCooldownTime;
        private float globalConchCooldown = 3f;
        private bool isGlobalCooling;
    }
}
