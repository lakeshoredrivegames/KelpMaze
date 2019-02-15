using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class SwordItem : Equipable
    {
        public override void Execute(PlayerManager player)
        {
            if (isCooling)
            {
                if (Time.time >= swordCooldownTime)
                {
                    isCooling = false;
                }
            }
            else
            {
                Debug.Log("Swinging the sword!");
                Animator anim;
                if(player.swordLevel == 1)
                {
                    anim = player.branchMesh.GetComponent<Animator>();
                }
                else
                {
                    anim = player.swordMesh.GetComponent<Animator>();
                }
                if(anim != null)
                {
                    anim.Play("SwordSlash");
                }
                player.audio.clip = player.equipSwordClip;
                player.audio.Play();

                // Check if hit object
                GameObject playerObj = player.gameObject;
                RaycastHit hit;

                Debug.DrawRay(playerObj.transform.position, playerObj.transform.forward, Color.green);
                if (Physics.Raycast(playerObj.transform.position, playerObj.transform.forward, out hit, maxAttackRange))
                {
                    if(hit.transform != null)
                    {
                        player.audio.clip = player.swordHitClip;
                        player.audio.Play();
                        Breakable breakableObj = hit.transform.gameObject.GetComponent<Breakable>();
                        if(breakableObj != null)
                        {
                            breakableObj.Hit(player);
                        }
                    }
                }
                isCooling = true;
                swordCooldownTime = Time.time + swordCooldown;
            }
        }

        private float maxAttackRange = 1f;
        private float swordCooldown = 1f;
        private bool isCooling;
        private float swordCooldownTime;
    }
}
